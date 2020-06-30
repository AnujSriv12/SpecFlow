using NUnit.Framework;
using SpecFlow.Step_Definitions;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using SpecFlow.Assist.Dynamic;

namespace SpecFlow
{
    [Binding]
    class SampleFeatureSteps
    {
        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int numbers)
        {

            Console.WriteLine(numbers);
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            Console.WriteLine("Pressed Add Button");
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int result)
        {
           if(result == 120)
            {
                Console.WriteLine("Test Passed");
            }
            else
            {
                Console.WriteLine("Test Failed");
                throw new Exception("Value is different");
            }
        }

        [When(@"I fill the mandatory details in form")]
        public void WhenIFillTheMandatoryDetailsInForm(Table table)
        {
            /*var details =  table.CreateSet<EmployeeDetails>();
             foreach (EmployeeDetails emp in details)
             {
                 Console.WriteLine(emp.Age);
                 Console.WriteLine(emp.Email);
                 Console.WriteLine(emp.Name);
                 Console.WriteLine(emp.Phone);
             }*/

            //Dynamic assist - No use of custom class
            var details = table.CreateDynamicSet();
            foreach (var emp in details)
            {
                Console.WriteLine("The Employee name is: " + emp.Name);
                Console.WriteLine("The Employee age is: " + emp.Age);
                Console.WriteLine("The Employee phone is: " + emp.Phone);
                Console.WriteLine("The Employee email is: " + emp.Email);

            }
        }

        [When(@"I fill the mandatory details in form (.*), (.*) and (.*)")]
        public void WhenIFillTheMandatoryDetailsInFormAnujAnd(string name, int age, long phone)
        {
            Console.WriteLine("Name:" + name);
            Console.WriteLine("Age:" + age);
            Console.WriteLine("Phone :" + phone);

            ScenarioContext.Current["InfoforNextStep"] = "Step1 Passed";

            Console.WriteLine(ScenarioContext.Current["InfoforNextStep"].ToString());

            List<EmployeeDetails> empDetails = new List<EmployeeDetails>()
            {
                new EmployeeDetails()
                {
                    Name = "Abrahim",
                    Age = 20,
                    Email = "test@testemail.com",
                    Phone = 12124123123
                },

                new EmployeeDetails()
                {
                    Name = "Mike",
                    Age = 22,
                    Email = "test1@testemail.com"
                }
        };

            ScenarioContext.Current.Add("EmpDetails",empDetails);

            var emplist = ScenarioContext.Current.Get<IEnumerable<EmployeeDetails>>("EmpDetails");

            foreach (EmployeeDetails emp in emplist)
            {
                Console.WriteLine("The Employee name is" + emp.Name);
                Console.WriteLine("The Employee age is" + emp.Age);
                Console.WriteLine("The Employee phone is" + emp.Phone);
                Console.WriteLine("The Employee email is" + emp.Email);
                Console.WriteLine();
            }

        }



    }
}
