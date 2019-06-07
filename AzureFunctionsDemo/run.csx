#r "Newtonsoft.Json"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public static IActionResult Run(HttpRequest req, TraceWriter log)
{
	log.Info("C# HTTP trigger function processed a request.");

	// Parsing query parameters
	string name = req.Query["name"];
	log.Info("name = " + name);

	string numberOfTerms = req.Query["numberOfTerms"];
	log.Info("numberOfTerms = " + numberOfTerms);

	// Validating the parameters received
	if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(numberOfTerms))
	{
		return new BadRequestObjectResult("Please pass a name and the number of digits on the query string."); 
	}

	int numberClient;
	try
	{
        numberClient = Int32.Parse(numberOfTerms);
	}
	catch (FormatException e)
	{
		return new BadRequestObjectResult("The numberOfTerms parameter must be an integer!"); 
	}

	if (numberClient < 0 || numberClient > 10000) {
		return new BadRequestObjectResult("Please pass a numberOfTerms parameter between 0 and 10000."); 
	}

	// Building the response
	string incompleteResponse = "Hello, " + name;
	string completeResponse = VerificateNumber(incompleteResponse, numberClient);
	var response = new OkObjectResult(completeResponse); 

	// Returning the HTTP response with the string we created
	log.Info("response = " + response);
	return response;
}




public static string VerificateNumber(string incompleteResponse, int numberClient)
{    

   
    int MyNUMBER = 10;
  
    if(MyNUMBER == numberClient)
    {
        string result = incompleteResponse + temporalString + "-You number is incorrect , choose another ";
        return result;
    }
    else
    {
        string result = incompleteResponse + temporalString + "-¡¡Congratulations!!";
        return result;
    }


    
}
