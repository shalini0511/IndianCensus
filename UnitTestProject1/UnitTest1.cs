using System;
using IndianCensusAnalyserProblem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //Interface
        IStateCensusCsvOperations censusAnalyzer;
        CsvAdapterFactory getCensusAdapter;

        //Path for Indian State Census
        string censusFilePath = @"C:\Users\HP\source\repos\IndianCensusProject\IndianCensusProject\IndianStateCensusInformation.csv";
        string invalidFileCsvPath = @"C:\Users\HP\source\repos\IndianCensusProject\IndianCensusProject\InvalidCensusFile.csv";
        string invalidFileTypePath = @"C:\Users\HP\source\repos\IndianCensusProject\IndianCensusProject\InvalidCensusFile.css";
        string invalidDelimiterFilePath = @"C:\Users\HP\source\repos\IndianCensusProject\IndianCensusProject\IndianStateCensusWithInvalidDelimiter.csv";
        string invalidHeaderFilePath = @"C:\Users\HP\source\repos\IndianCensusProject\IndianCensusProject\IndianStateCensusWithInvalidHeader.csv";


        [TestInitialize]
        public void SetUp()
        {
            getCensusAdapter = new CsvAdapterFactory();
        }

        //TC1.1: Count the number of records
        [TestMethod]
        [TestCategory("Given State Census CSV return Count of fields")]
        public void TestMethodToCheckCountOfDataRetrieved()
        {
            int expected = 29;
            string[] result = getCensusAdapter.LoadCsvData(CountryChecker.Country.INDIA, censusFilePath, "﻿State,Population,Increase,Area,Density");
            int actual = result.Length;
            Assert.AreEqual(expected, actual);
        }

        //TC1.2:Check whether File exists
        [TestMethod]
        [TestCategory("Check Whether File Exists")]
        public void TestMethodToCheckInvalidFile()
        {
            try
            {
                getCensusAdapter.LoadCsvData(CountryChecker.Country.INDIA, invalidFileCsvPath, "State,Population,Increase,Area,Density");

            }
            catch (CensusCustomException ex)
            {
                Assert.AreEqual(ex.Message, "File not found!");
            }
        }

        //TC1.3:Check for correct Extension
        [TestMethod]
        [TestCategory("Invalid File Extension")]
        public void TestMethodToCheckInvalidFileExtension()
        {
            try
            {
                getCensusAdapter.LoadCsvData(CountryChecker.Country.INDIA, invalidFileTypePath, "State,Population,Increase,Area,Density");

            }
            catch (CensusCustomException ex)
            {
                Assert.AreEqual(ex.Message, "Invalid Extension");
            }
        }
        //TC1.4:Check for proper Delimiter
        [TestMethod]
        [TestCategory("Delimiter Check")]
        public void TestMethodToCheckInvalidDelimiter()
        {
            try
            {
                getCensusAdapter.LoadCsvData(CountryChecker.Country.INDIA, invalidDelimiterFilePath, "State,Population,Increase,Area,Density");

            }
            catch (CensusCustomException ex)
            {
                Assert.AreEqual(ex.Message, "Invalid Delimiter");
            }
        }
        //TC1.5: Check for incorrect header
        [TestMethod]
        [TestCategory("Incorrect Header")]
        public void TestMethodToCheckIncorrectHeader()
        {
            try
            {
                getCensusAdapter.LoadCsvData(CountryChecker.Country.INDIA, invalidHeaderFilePath, "State,Population,Increase,Area,Density");
            }
            catch (CensusCustomException ex)
            {
                Assert.AreEqual(ex.Message, "Incorrect Header");
            }
        }
    }
}