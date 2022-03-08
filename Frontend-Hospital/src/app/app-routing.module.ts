import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { PatientListComponent } from './components/patient-list/patient-list.component';
import { PatientDetailsComponent } from './components/patient-details/patient-details.component';
import { PatientCreateComponent } from './components/patient-create/patient-create.component';
const routes: Routes = [
  { path: '', redirectTo: 'patients', pathMatch: 'full' },
  { path: 'patients', component: PatientListComponent },
  { path: 'patients/getall', component: PatientDetailsComponent },
  { path: 'create', component: PatientCreateComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
