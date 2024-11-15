using FilterTreeControlWPF;

namespace RevitAddinBootcamp_TW2
{
    [Transaction(TransactionMode.Manual)]
    public class cmdChallenge01 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // Revit application and document variables
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            // Variables

            //Number Variables
            int nv = 10;
            int se = 0;
            int f = 15;
            int ln = se + 1;


            // find the remainder when dividing (ie. the modulo or mod)
            double remainderX = ln % 3; // equals 0 (100 divided by 10 = 10)
            double remainderY = ln % 5; // equals 0 (100 divided by 10 = 10)

            // Your Module 01 Challenge code goes here
            // Delete the TaskDialog below and add your code




            // create a transaction to lock the model
            Transaction t = new Transaction(doc);
            t.Start("Here we go");

            // create a filtered element collector to get view family type
            FilteredElementCollector collector1 = new FilteredElementCollector(doc);
            collector1.OfClass(typeof(ViewFamilyType));

            ViewFamilyType floorPlanVFT = null;
            foreach (ViewFamilyType curVFT in collector1)
            {

                if (curVFT.ViewFamily == ViewFamily.FloorPlan)
                {
                    floorPlanVFT = curVFT;
                }

            }


            ViewFamilyType ceilingPlanVFT = null;
            foreach (ViewFamilyType curVFT in collector1)
            {
                if (curVFT.ViewFamily == ViewFamily.CeilingPlan)
                {
                    ceilingPlanVFT = curVFT;
                }
            }


            // loop through a range of numbers
            for (int i = ln; i <= nv; i++)
            {

                // create a floor level 
                Level newlevel = Level.Create(doc, f * i);
                newlevel.Name = "Level" + i;

                // create modulus for 3 and 5
                double remainder3 = i % 3;
                double remainder5 = i % 5;



                // create floor plan if level # is divisible by 3
                if (remainder3 == 0)
                {

                    // create a floor plan view
                    ViewPlan newFloorPlan = ViewPlan.Create(doc, floorPlanVFT.Id, newlevel.Id);


                }


                // create ceiling plan if level # is divisible by 5
                if (remainder5 == 0)
                {


                    // create a ceiling plan view
                    ViewPlan newCeilingPlan = ViewPlan.Create(doc, ceilingPlanVFT.Id, newlevel.Id);


                }


            }
















            t.Commit();
            t.Dispose();










            return Result.Succeeded;
        }
        internal static PushButtonData GetButtonData()
        {
            // use this method to define the properties for this command in the Revit ribbon
            string buttonInternalName = "btnChallenge01";
            string buttonTitle = "Module\r01";
            Common.ButtonDataClass myButtonData = new Common.ButtonDataClass(
            buttonInternalName,
                buttonTitle,
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                Properties.Resources.Module01,
                Properties.Resources.Module01,
                "Module 01 Challenge");

            return myButtonData.Data;
        }
    }

}
