import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { EmployeeService } from '../../services/employee.service';
import { RolesService } from '../../services/roles.service';
import { Role } from '../../models/role.model';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {provideNativeDateAdapter} from '@angular/material/core';
import { RoleEmployee } from '../../models/roleEmployee.model';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { Employee } from '../../models/employee.model';
import { error } from 'console';
import {MatSelectModule} from '@angular/material/select';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-add-employee',
  standalone: true,
  providers: [provideNativeDateAdapter()],
  imports: [CommonModule, FormsModule, ReactiveFormsModule, MatFormFieldModule, MatInputModule, HttpClientModule,
    MatDialogModule, MatButtonModule, MatSelectModule, MatDatepickerModule],
  templateUrl: './add-employee.component.html',
  styleUrl: './add-employee.component.scss'
})
export class AddEmployeeComponent implements OnInit {

  minDate!: Date;
  maxDate!: Date;
  formGroup!: FormGroup;
  roles!: Role[];
  employee!: Employee;
  jobDetailsFormArray!: FormArray;
  jobTitles!: Role[];

  constructor(private router: Router, private _employeeService: EmployeeService, private _roleService: RolesService) {
  
}
private setMinMaxDates(): void {
  const currentYear = new Date().getFullYear();
  this.minDate = new Date(currentYear - 20, 0, 1);
  this.maxDate = new Date(currentYear + 1, 11, 31);
}
  
  
  ngOnInit() {
    this.initFormGroup();
    this.getAlljobTitles();
    this.setMinMaxDates();
  }

  getAlljobTitles(){
    this._roleService.getAllRoles().subscribe(res => {
      this.jobTitles = res
    })
  }

  initFormGroup() {
    this.formGroup = new FormGroup({
      "firstName": new FormControl('', [Validators.required]),
      "lastName": new FormControl('', [Validators.required]),
      "tz": new FormControl('', [Validators.required]),
      "dateOfBirth": new FormControl (null),
      "gander": new FormControl(true),
      "beginningOfWork": new FormControl([Validators.required]),
      "employeeRoles": new FormArray([])
    });
    this.jobDetailsFormArray = this.formGroup.get('employeeRoles') as FormArray;
  }

  
  addRole() {
    this._roleService.postRole(this.rolesFormArray.value).subscribe();
  }

  get rolesFormArray() {
    return this.formGroup.get('employeeRoles') as FormArray;
  }

  removeThisJob(index: number) {
    this.rolesFormArray.removeAt(index);
  }

  addNewJob() {
    this.rolesFormArray.push(new FormGroup({
      "jobTitle": new FormControl([0, Validators.required]),
      "isManagement": new FormControl([true]),
      "dateOfEntryToWork": new FormControl([new Date])
    }));
  }

  onSubmit() {
    console.log("this.formGroup.value",this.formGroup.value)
    this._employeeService.addEmployee(this.formGroup.value).subscribe(res => {
    }, (err) => {
      console.log(err)
    })
    this.router.navigate(['/allEmployees'])
  }

  filterdateOfBirth = (dt: Date | null): boolean => {
    const seventyYearsAgo = new Date();
    seventyYearsAgo.setFullYear(seventyYearsAgo.getFullYear() - 70);
    return !!(dt && dt.getTime() > seventyYearsAgo.getTime());
  };

  filterbeginningOfWork = (dt: Date | null): boolean => {
    const minWorkStartDate = new Date(
      this.formGroup.get('dateOfBirth')!.value!
    );
    minWorkStartDate.setFullYear(minWorkStartDate.getFullYear() + 18);
    return !dt || dt >= minWorkStartDate;
  };

  filterdateOfEntryToWork = (dt: Date | null): boolean => {
    const minWorkStartDate = new Date(
      this.formGroup.get('beginningOfWork')!.value!
    );
    minWorkStartDate.setFullYear(minWorkStartDate.getFullYear());
    return !dt || dt >= minWorkStartDate;
  };


}
