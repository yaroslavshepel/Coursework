using BusinessLogic.Doctors;

namespace BusinessLogic.DataOperations;

public abstract class DataOperationsBase<T>
{
    protected List<T> Items = new List<T>();

    public abstract void Add(T item);
    public abstract void Remove(T item);
    public abstract T FindById(string id);
    public List<T> GetAll()
    {
        return Items;
    }
}

public class DoctorDataOperations : DataOperationsBase<DoctorClass>
{
    public override void Add(DoctorClass doctor)
    {
        Items.Add(doctor);
    }

    public override void Remove(DoctorClass doctor)
    {
        Items.Remove(doctor);
    }

    public override DoctorClass FindById(string id)
    {
        return Items.Find(d => d.DoctorId == id) ?? throw new CustomException("Doctor not found.");
    }
}