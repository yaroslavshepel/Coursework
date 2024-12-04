using BusinessLogic.Patients;

namespace BusinessLogic.MedicalRecords;

public class MedicalRecordClass
{
    private DateTime _recordCreationDate;
    private string _recordId = "";
    private string _doctorId = "";
    private string _diagnosis = "";
    private string _treatment = "";
    
    public DateTime RecordCreationDate { get => _recordCreationDate; set => _recordCreationDate = value; }
    public string RecordId { get => _recordId; set => _recordId = value; }
    public string DoctorId { get => _doctorId; set => _doctorId = value; }
    public string Diagnosis { get => _diagnosis; set => _diagnosis = value; }
    public string Treatment { get => _treatment; set => _treatment = value; }
    
    public MedicalRecordClass() { }
    
    public MedicalRecordClass(DateTime recordCreationDate, string recordId, string doctorId, string diagnosis, string treatment)
    {
        _recordCreationDate = recordCreationDate;
        _recordId = recordId;
        _doctorId = doctorId;
        _diagnosis = diagnosis;
        _treatment = treatment;
    }
    
    public static MedicalRecordClass AddRecord(string doctorId, string diagnosis, string treatment)
    {
        string recordId = PatientsArray.Patients.Last().MedicalRecord.RecordId;
        string patientIdTrimmed = recordId.Trim('R', 'M');
        int recordIdNumber = int.Parse(patientIdTrimmed);
        string newRecordId = $"MR{recordIdNumber + 1}";
        return new MedicalRecordClass(DateTime.Now, newRecordId, doctorId, diagnosis, treatment);
    }

    public MedicalRecordClass EditRecord(string recordId, string doctorId, string diagnosis, string treatment)
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