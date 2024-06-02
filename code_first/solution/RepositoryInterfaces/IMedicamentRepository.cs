namespace solution.Repository;

public interface IMedicamentRepository
{
    public Task<bool> CheckMedicamentExists(int medicamentId);

}