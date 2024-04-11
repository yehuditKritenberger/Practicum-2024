import { Routes } from '@angular/router';
import { AllEmployeesComponent } from './components/all-employees/all-employees.component';
import { AddEmployeeComponent } from './components/add-employee/add-employee.component';
import { EditEmployeeComponent } from './components/edit-employee/edit-employee.component';

export const routes: Routes = [

  { path: '', redirectTo: "allEmployees", pathMatch: "full" },
  { path: "allEmployees", component: AllEmployeesComponent},
  { path: "addEmployee", component: AddEmployeeComponent},
  { path: "editEmployee/:id", component: EditEmployeeComponent}

];
