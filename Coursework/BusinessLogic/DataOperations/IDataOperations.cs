using BusinessLogic.Patients;

namespace BusinessLogic.DataOperations;

public interface IDataOperations<T>
{
    void Add(T item);
    void Remove(T item);
    T FindById(string id);
    List<T> GetAll();
}

public class PatientDataOperations : IDataOperations<PatientClass>
{
    private List<PatientClass> _patients = new List<PatientClass>();

    public void Add(PatientClass patient)
    {
        _patients.Add(patient);
    }

    public void Remove(PatientClass patient)
    {
        _patients.Remove(patient);
    }

    public PatientClass FindById(string id)
    {
        return _patients.Find(p => p.PatientId == id) ?? throw new CustomException("Patient not found.");
    }

    public List<PatientClass> GetAll()
    {
        return _patients;
    }
}