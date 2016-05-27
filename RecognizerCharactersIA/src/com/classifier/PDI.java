/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.classifier;

import java.awt.Graphics2D;
import java.awt.image.BufferedImage;
import java.awt.image.ConvolveOp;
import java.awt.image.Kernel;

/**
 *
 * @author rafaelclp
 */
public class PDI {
    private static int R(BufferedImage imagem, int x, int y) {
        return (imagem.getRGB(x, y) >> 16) & 0xff;
    }
    private static int G(BufferedImage imagem, int x, int y) {
        return (imagem.getRGB(x, y) >> 8) & 0xff;
    }
    private static int B(BufferedImage imagem, int x, int y) {
        return imagem.getRGB(x, y) & 0xff;
    }
    private static int toRGB(int r, int g, int b) {
        r = Math.min(255, Math.max(0, r));
        g = Math.min(255, Math.max(0, g));
        b = Math.min(255, Math.max(0, b));
        return (r << 16) + (g << 8) + b;
    }

    /**
     * Informa se uma cor, ao ser convertida para B/W, é B (preta).
     * 
     * @param rgb RGB da cor a ser analisada.
     * @return True, se for preta; false, se for branca.
     */
    public static boolean ehPreto(int rgb) {
        int r = (rgb >> 16) & 0xff;
        int g = (rgb >> 8) & 0xff;
        int b = rgb & 0xff;
        return (r + g + b) / 3 >= 128;
    }

    public static BufferedImage cortarBloco(BufferedImage imagemOriginal, int x, int y, int larguraBloco, int alturaBloco) {
        // Ajusta o tamanho do bloco caso passe dos limites da imagem original
        larguraBloco = Math.min(larguraBloco, imagemOriginal.getWidth() - x);
        alturaBloco = Math.min(alturaBloco, imagemOriginal.getHeight() - y);

        BufferedImage imagemCortada = new BufferedImage(
            larguraBloco, alturaBloco, imagemOriginal.getType()
        );

        Graphics2D gr = imagemCortada.createGraphics();
        gr.drawImage(
            imagemOriginal, // imagem de onde sera copiado o retangulo
            0, 0, larguraBloco, alturaBloco, // dstx1,dsty1,dstx2,dsty2
            x, y, x + larguraBloco, y + alturaBloco, // srcx1,srcy1,srcx2,srcy2
            null
        );
        gr.dispose();

        return imagemCortada;
    }

    /**
     * Aplica convolução com uma máscara usando a biblioteca padrão do Java.
     * 
     * @param imagemOriginal Imagem onde será aplicado o operador de convolução.
     * @param larguraMascara Largura da máscara (kernel) de convolução.
     * @param mascara Máscara (kernel) de convolução.
     * @return Nova imagem, com operador de convolução aplicado.
     */
    public static BufferedImage convolucao(BufferedImage imagemOriginal, int larguraMascara, float[] mascara) {
        BufferedImage imagemRes = new BufferedImage(
            imagemOriginal.getWidth(), imagemOriginal.getHeight(),
            imagemOriginal.getType()
        );
        Kernel kernel = new Kernel(larguraMascara,
            mascara.length / larguraMascara, mascara
        );
        ConvolveOp convOp = new ConvolveOp(kernel, ConvolveOp.EDGE_NO_OP, null);
        convOp.filter(imagemOriginal, imagemRes);
        return imagemRes;
    }

    /**
     * Aplica convolução com duas máscaras assumindo que a magnitude final G do
     * pixel pode ser calculada por raiz(Gx²+Gy²), ou seja, que uma máscara tem
     * efeito no eixo X e a outra no eixo Y (sendo perpendiculares).
     * 
     * @param imagemOriginal Imagem onde será aplicado o operador de convolução.
     * @param larguraMascara Largura das máscaras (kernels) de convolução.
     * @param mascaraX Máscara (kernel) de convolução no eixo X.
     * @param mascaraY Máscara (kernel) de convolução no eixo Y.
     * @return Nova imagem, com operador de convolução aplicado.
     */
    public static BufferedImage convolucaoXY(BufferedImage imagemOriginal, int larguraMascara, double[] mascaraX, double[] mascaraY) {
        int largura = imagemOriginal.getWidth();
        int altura = imagemOriginal.getHeight();
        int alturaMascara = mascaraX.length / larguraMascara;

        BufferedImage imagemRes = new BufferedImage(
            largura, altura, imagemOriginal.getType()
        );

        for (int i = 0; i < altura; i++) {
            for (int j = 0; j < largura; j++) {
                double rx = 0, gx = 0, bx = 0;
                double ry = 0, gy = 0, by = 0;
                for (int di = 0; di < alturaMascara; di++) {
                    for (int dj = 0; dj < larguraMascara; dj++) {
                        int y = i - alturaMascara / 2 + di;
                        int x = j - larguraMascara / 2 + dj;
                        
                        if (y < 0 || y >= altura || x < 0 || x >= largura) {
                            continue;
                        }

                        double cx = mascaraX[di*larguraMascara + dj];
                        rx += R(imagemOriginal, x, y) * cx;
                        gx += G(imagemOriginal, x, y) * cx;
                        bx += B(imagemOriginal, x, y) * cx;
                        
                        double cy = mascaraY[di*larguraMascara + dj];
                        ry += R(imagemOriginal, x, y) * cy;
                        gy += G(imagemOriginal, x, y) * cy;
                        by += B(imagemOriginal, x, y) * cy;
                    }
                }
                int r = (int)Math.sqrt(rx * rx + ry * ry);
                int g = (int)Math.sqrt(gx * gx + gy * gy);
                int b = (int)Math.sqrt(bx * bx + by * by);
                //int r = (int)(Math.abs(rx) + Math.abs(ry));
                //int g = (int)(Math.abs(gx) + Math.abs(gy));
                //int b = (int)(Math.abs(bx) + Math.abs(by));
                imagemRes.setRGB(j, i, toRGB(r, g, b));
            }
        }
        return imagemRes;
    }

    /**
     * Aplica operador de Scharr em uma imagem para detecção de bordas. É mais
     * preciso do que o operador de Sobel ou o de Prewitt (testei e confirmei).
     * 
     * @see http://docs.opencv.org/2.4/doc/tutorials/imgproc/imgtrans/sobel_derivatives/sobel_derivatives.html
     * 
     * @param imagemOriginal Imagem onde será aplicado o operador de Scharr.
     * @return Nova imagem, com operador de Scharr aplicado.
     */
    public static BufferedImage Scharr(BufferedImage imagemOriginal) {
        return convolucaoXY(imagemOriginal, 3,
            new double[]{-3, 0, 3, -10, 0, 10, -3, 0, 3},
            new double[]{-3, -10, -3, 0, 0, 0, 3, 10, 3}
        );
    }

    /**
     * Aplica operador de Sobel em uma imagem para detecção de bordas.
     * 
     * @param imagemOriginal Imagem onde será aplicado o operador de Sobel.
     * @return Nova imagem, com operador de Sobel aplicado.
     */
    public static BufferedImage Sobel(BufferedImage imagemOriginal) {
        return convolucaoXY(imagemOriginal, 3,
            new double[]{-1, 0, 1, -2, 0, 2, -1, 0, 1},
            new double[]{-1, -2, -1, 0, 0, 0, 1, 2, 1}
        );
    }

    private static BufferedImage converterEspacoCores(BufferedImage imagemOriginal, int espacoCores) {
        BufferedImage imagemGrayscale = new BufferedImage(
            imagemOriginal.getWidth(), imagemOriginal.getHeight(), espacoCores
        );
        Graphics2D gr = imagemGrayscale.createGraphics();
        gr.drawImage(imagemOriginal, 0, 0, null);
        return imagemGrayscale;
    }

    public static BufferedImage converterParaGrayscale(BufferedImage imagemOriginal) {
        return converterEspacoCores(imagemOriginal, BufferedImage.TYPE_BYTE_GRAY);
    }

    public static BufferedImage converterParaBW(BufferedImage imagemOriginal) {
        return converterEspacoCores(imagemOriginal, BufferedImage.TYPE_BYTE_BINARY);
    }

    public static BufferedImage inverterCores(BufferedImage imagemOriginal) {
        BufferedImage imagemInvertida = new BufferedImage(
            imagemOriginal.getWidth(), imagemOriginal.getHeight(),
            imagemOriginal.getType()
        );
        for (int y = 0; y < imagemOriginal.getHeight(); y++) {
            for (int x = 0; x < imagemOriginal.getWidth(); x++) {
                int r = 255 - R(imagemOriginal, x, y);
                int g = 255 - G(imagemOriginal, x, y);
                int b = 255 - B(imagemOriginal, x, y);
                imagemInvertida.setRGB(x, y, toRGB(r, g, b));
            }
        }
        return imagemInvertida;
    }

    /**
     * Ajusta uma imagem da melhor forma para posteriormente ser usada em um
     * classificador OCR.
     * 
     * @param imagemOriginal Imagem original
     * @return Imagem após a aplicação de uma sequência de métodos de PDI.
     */
    public static BufferedImage ajustarParaOCR(BufferedImage imagemOriginal) {
        BufferedImage imagem = converterParaGrayscale(imagemOriginal);
        imagem = Scharr(imagem);
        imagem = converterParaBW(imagem);
        imagem = inverterCores(imagem);
        return imagem;
    }

    public static BufferedImage debug(BufferedImage imagemOriginal) {
        return ajustarParaOCR(imagemOriginal);
    }
}
