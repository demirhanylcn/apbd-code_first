namespace solution.Exception;

public class PrescriptionDoesntExistsException : System.Exception
{
    public PrescriptionDoesntExistsException(int patientId) : base($"prescription with the given patientId {patientId} doesnt exists.")
    {

    }
}