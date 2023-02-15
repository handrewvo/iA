# iA
iA coding challenge

Download code and run the applciation.  The project has no dependencies or packages to add.

Assumptions:
Medication data global across all fills/lines (example given in challenge had a different price for Medication A at different fill stations)
  Each central fill facility has different medications (A, B, C) as Inventory. - I assumed meant the fill stations each had different combinations of medications

Changes to program if multiple fills at location:
Quantity of specified medication needed to fulfill Rx.  This could be used to calculate how long a bottle would be at the central fill and better optimize releases given travel time to filler.
Quantity of medication at a central fill, this would allow application to give priority to central fills that have the quantities to successfully fill a given Rx.
Having a queue at each filler and managing expected fill times given # of pills needed

Changes given larger world size:
Remove the constraints on x/y range
Would need to handle multiple central fills per co-ordinate 
Quantity needed vs what is in the central fill would be needed so there aren't partial fills (unless there is another system to handle that)
If the system does do partials, maybe have code to pass the Rx down line to next central fill with same drug to complete fill
