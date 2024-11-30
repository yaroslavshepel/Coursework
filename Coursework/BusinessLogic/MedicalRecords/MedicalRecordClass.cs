using BusinessLogic.Patients;

namespace BusinessLogic.MedicalRecords;

public class MedicalRecordClass
{
    private DateTime _recordCreationDate;
    private int _recordId;
    private int _doctorId;
    private string _diagnosis = "";
    private string _treatment = "";
    
    public MedicalRecordClass() { }
    
    public DateTime RecordCreationDate { get => _recordCreationDate; set => _recordCreationDate = value; }
    public int RecordId { get => _recordId; set => _recordId = value; }
    public int DoctorId { get => _doctorId; set => _doctorId = value; }
    public string Diagnosis { get => _diagnosis; set => _diagnosis = value; }
    public string Treatment { get => _treatment; set => _treatment = value; }
    
    public MedicalRecordClass(DateTime recordCreationDate, int recordId, int doctorId, string diagnosis, string treatment)
    {
        _recordCreationDate = recordCreationDate;
        _recordId = recordId;
        _doctorId = doctorId;
        _diagnosis = diagnosis;
        _treatment = treatment;
    }
    
    public static MedicalRecordClass AddRecord(int doctorId, string diagnosis, string treatment)
    {
        return new MedicalRecordClass(DateTime.Now, PatientsArray.Patients.Last().MedicalRecord.RecordId + 1, doctorId, diagnosis, treatment);
    }

    public MedicalRecordClass EditRecord(int recordId, int doctorId, string diagnosis, string treatment)
    {
        RecordId = recordId;
        DoctorId = doctorId;
        Diagnosis = diagnosis;
        Treatment = treatment;
        return new MedicalRecordClass(DateTime.Now, recordId, doctorId, diagnosis, treatment);
    }
    
    public string PrintRecord()
    {
        return $"Record ID: {_recordId}, Doctor ID: {_doctorId}, Diagnosis: {_diagnosis}, Treatment: {_treatment}, Record Creation Date: {_recordCreationDate}";
    }
}