Console.WriteLine("Hello, World!");

using var db = new FNContext();

var testJoiningHub = from mortgageAgnt in db.MortgageAgents
                  join hAgnt in db.HubAgents
                   on mortgageAgnt.HubAgentCode equals hAgnt.Code
                  where mortgageAgnt.Active == 1
                  select new
                  {
                      agntCode = mortgageAgnt.HubAgentCode,
                      mortgageNumber = mortgageAgnt.Number,
                      hubAgntActivity = hAgnt.Active,
                  };
foreach (var test in testJoiningHub)
{
    Console.WriteLine($"{test.agntCode} is an hub agent managing {test.mortgageNumber}");
}

var testJoiningDirect = db.MortgageAgents.Join(db.DirectAgents, 
      mortgageAgnt => mortgageAgnt.DirectAgentCode,
      dAgnt => dAgnt.Code, 
      (mortgageAgnt, dAgnt) 
      => new
      {
          agntCode = mortgageAgnt.DirectAgentCode,
          mortgageNumber = mortgageAgnt.Number,
          directAgntActivity = dAgnt.Active
      })
    .Where(a=>a.directAgntActivity == 1 );
foreach (var test in testJoiningDirect)
{
    Console.WriteLine($"{test.agntCode} is an active direct agent managing {test.mortgageNumber}");
}


db.Dispose();
Console.ReadLine();