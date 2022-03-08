import { Component, OnInit } from '@angular/core';
import { PatientService } from 'src/app/services/patient.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-patient-details',
  templateUrl: './patient-details.component.html',
  styleUrls: ['./patient-details.component.css']
})
export class PatientDetailsComponent implements OnInit {

  message = '';
  currentPatient: any;

  constructor(
    private patientService: PatientService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.message = '';
    this.getPatient(this.route.snapshot.paramMap.get('id'));
  }

  getPatient(id: string | null): void {
    this.patientService.read(id)
      .subscribe(
        patient => {
          this.currentPatient = patient;
          console.log(patient);
        },
        error => {
          console.log(error);
        });
  }

  setAvailableStatus(status: any): void {
    const data = {
      name: this.currentPatient.name,
      fileNo: this.currentPatient.fileNo,
      citizenId: this.currentPatient.citizenId,
      birthDate: this.currentPatient.birthDate,
      gender: this.currentPatient.gender,
      natinality: this.currentPatient.natinality,
      phoneNumber: this.currentPatient.phoneNumber,
      email: this.currentPatient.email,
      country: this.currentPatient.country,
      city: this.currentPatient.city,
      street: this.currentPatient.street,
      address1: this.currentPatient.address1,
      address2: this.currentPatient.address2,
      contactPerson: this.currentPatient.contactPerson,
      contactRelation: this.currentPatient.contactRelation,
      contactPhone: this.currentPatient.contactPhone,
      firstVisitDate: this.currentPatient.firstVisitDate,
      available: status
    };

    this.patientService.update(this.currentPatient.id, data)
      .subscribe(
        response => {
          this.currentPatient.available = status;
          console.log(response);
        },
        error => {
          console.log(error);
        });
  }

  updatePatient(): void {
    this.patientService.update(this.currentPatient.id, this.currentPatient)
      .subscribe(
        response => {
          console.log(response);
          this.message = 'The patient was updated!';
        },
        error => {
          console.log(error);
        });
  }

  deletePatient(): void {
    this.patientService.delete(this.currentPatient.id)
      .subscribe(
        response => {
          console.log(response);
          this.router.navigate(['/patients']);
        },
        error => {
          console.log(error);
        });
  }
}

