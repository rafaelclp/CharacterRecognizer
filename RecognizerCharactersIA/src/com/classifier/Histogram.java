package com.classifier;

import javax.imageio.ImageIO;
import java.awt.*;
import java.awt.image.BufferedImage;
import java.io.File;
import java.util.ArrayList;
import java.util.Collections;
import java.util.HashSet;
import java.util.List;

/**
 * Created by marcos on 4/17/16.
 */
public class Histogram {

    private static final int HIST_SIZE = 256;
    
    /**
     * Parses pixels out of an image file, converts the RGB values to
     * its equivalent grayscale value (0-255), then constructs a
     * histogram of the percentage of counts of grayscale values.
     *
     * @param input - the image.
     * @return - a histogram of grayscale percentage counts.
     * @throws java.lang.Exception
     */
    protected static double[] buildHistogram(BufferedImage input) throws Exception {
        input = resizeImage(input);
        int width = input.getWidth();
        int height = input.getHeight();
        
        input = PDI.ajustarParaOCR(input);

        double[] histogram = new double[HIST_SIZE];
        int total_b_pixels = 0;
        for (int col = 0; col < height; col++) {
            for (int row = 0; row < width; row++) {
                if (PDI.ehPreto(input.getRGB(row, col))) {
                    histogram[col]++;
                    total_b_pixels++;
                }
            }
        }

        if (total_b_pixels > 0) {
            for (int i = 0; i < HIST_SIZE; i++) {
                histogram[i] /= total_b_pixels;
            }
        }
    
        return histogram;
    }
    
    /**
     * Parses pixels out of an image file, converts the RGB values to
     * its equivalent grayscale value (0-255), then constructs a
     * histogram of the percentage of counts of grayscale values.
     *
     * @param infile - the image file.
     * @return - a histogram of grayscale percentage counts.
     * @throws java.lang.Exception
     */
    protected static double[] buildHistogram(File infile) throws Exception {
        return buildHistogram(ImageIO.read(infile));
    }

    private static BufferedImage resizeImage(BufferedImage originalImage){
        int type = originalImage.getType() == 0? BufferedImage.TYPE_INT_ARGB : originalImage.getType();
	BufferedImage resizedImage = new BufferedImage(HIST_SIZE, HIST_SIZE, type);
	Graphics2D g = resizedImage.createGraphics();
	g.drawImage(originalImage, 0, 0, HIST_SIZE, HIST_SIZE, null);
	g.dispose();
	return resizedImage;
    }
}
