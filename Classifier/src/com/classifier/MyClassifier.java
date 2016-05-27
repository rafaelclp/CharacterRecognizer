package com.classifier;

import static com.classifier.ClassifierSetBuilder.CAPACITY;
import static com.classifier.ClassifierSetBuilder.INDEX;
import java.awt.image.BufferedImage;
import java.io.Serializable;
import weka.classifiers.Classifier;
import weka.classifiers.trees.DecisionStump;
import weka.classifiers.functions.MultilayerPerceptron;
import weka.classifiers.bayes.NaiveBayes;
import weka.classifiers.bayes.BayesNet;
import weka.core.Attribute;
import weka.core.FastVector;
import weka.core.Instances;

import weka.core.Instance;

/**
 * Created by julio on 4/17/16.
 */
public class MyClassifier implements Serializable {

    private final Classifier model;
    private final ClassifierSetBuilder setBuilder;
    private final FastVector classes;
    
    public String last_train;
    public String classifierName;
    
    public static String[] classifiers = {"MultilayerPerceptron", "BayesNet", 
        "DecisionStump", "NaiveBayes"};


    public MyClassifier(FastVector classes, String classifier) {
        this.classes = classes;
        if (classifier.equals("MultilayerPerceptron")) {
            this.model = new MultilayerPerceptron();
        } else if (classifier.equals("BayesNet")) {
            this.model = new BayesNet();
        } else if (classifier.equals("DecisionStump")) {
            this.model = new DecisionStump();
        } else if (classifier.equals("NaiveBayes")) {
            this.model = new NaiveBayes();
        } else {
            this.model = new MultilayerPerceptron();
        }
        this.classifierName = classifier;
        this.setBuilder = new ClassifierSetBuilder(classes);
        this.last_train = "";
    }

    public void buildClassifier() throws Exception {
        this.model.buildClassifier(getSet());
    }

    public Classifier getClassifier() {
        return this.model;
    }
    
    public String classifyInstance(BufferedImage image) throws Exception {    
        FastVector wekaAttributes = new FastVector(CAPACITY);
        for (int i = 0; i < INDEX; i++) {
            Attribute attr = new Attribute("numeric" + i);
            wekaAttributes.addElement(attr);
        }
        Attribute attr = new Attribute("classes", classes);
        wekaAttributes.addElement(attr);
        
        Instances trainingSet = new Instances("Rel", wekaAttributes, 1);
        trainingSet.setClassIndex(INDEX);
        
        double[] histogram = Histogram.buildHistogram(image);
        Instance imageInstance = new Instance(ClassifierSetBuilder.CAPACITY);
        for (int i = 0; i < histogram.length; i++) {
            imageInstance.setValue((Attribute) wekaAttributes.elementAt(i), histogram[i]);
        }
        Instances dataUnlabeled = new Instances("TestInstances", wekaAttributes, 0);
        dataUnlabeled.add(imageInstance);
        dataUnlabeled.setClassIndex(dataUnlabeled.numAttributes() - 1); 
        String predicted = getSet().classAttribute().value((int) this.model.classifyInstance(dataUnlabeled.firstInstance()));

        return predicted;
    }

    public Instances getSet() {
        return this.setBuilder.getSet();
    }

    public void buildSet(String folderName, String classe) throws Exception {
        setBuilder.buildSet(folderName, classe);
    }
}
