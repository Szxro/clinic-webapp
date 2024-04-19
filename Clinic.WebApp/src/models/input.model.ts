export interface CreateDoctorForm {
  name: string;
  telephone: string;
  nif: string;
  socialNumber: string;
  collegueNumber: string;
  startDate: Date | null;
  doctorPosition: string;
}

export interface DeleteDoctorForm {
  doctorName: string;
  collegueNumber: string;
}

export interface UpdateDoctorForm {
  doctorName: string;
  telephone: string;
  collegueNumber: string;
  startDate: Date | null;
  doctorPosition: string;
}

export interface CreateDoctorPositionForm {
  positionName: string;
}

export interface CreatePatientForm {
  name: string;
  telephone: string;
  nif: string;
  socialNumber: number;
}

export interface UpdatePatientForm {
  name: string;
  telephone: string;
  nif: string;
}

export interface DeletePatientForm {
  name: string;
  nif: string;
}
