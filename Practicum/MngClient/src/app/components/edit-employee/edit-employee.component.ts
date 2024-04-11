import { Component, OnInit, Inject } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Employee } from '../../models/employee.model';
import { Role } from '../../models/role.model';
import { EmployeeService } from '../../services/employee.service';
import { RolesService } from '../../services/roles.service';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { HttpClientModule } from '@angular/common/http';
import { MatDialog, MatDialogActions, MatDialogClose, MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { provideNativeDateAdapter } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { ActivatedRoute, Router } from '@angular/router';
import { map } from 'rxjs';
import e from 'express';

@Component({
  selector: 'app-edit-employee',
  standalone: true,
  providers: [provideNativeDateAdapter()],
  imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpClientModule, MatFormFieldModule,
    MatInputModule, MatButtonModule, MatDialogModule, MatSelectModule, MatDatepickerModule],
  templateUrl: './edit-employee.component.html',
  styleUrl: './edit-employee.component.scss'
})
export class EditEmployeeComponent implements OnInit {

  formGroup!: FormGroup;
  employee!: Employee;
  initEmployee!: Employee
  jobDetailsFormArray!: FormArray;
  jobTitles!: Role[];
  constructor(private router: Router, private _activatedRoute: ActivatedRoute, 
    private _employeeService: EmployeeService, private _roleService: RolesService,
    public dialog: MatDialog
  ) { }

  ngOnInit() {
    this.initFormGroup();
    // this.getAlljobTitles();
    this.filterRole();
    this.currentEmp();
   }

  filterRole() {
    this._roleService.getAllRoles().pipe(map(roles =>
      this.jobTitles = roles.filter(role => !this.initEmployee.employeeRoles.some(e => e.roleId === role.id)))).subscribe(
        () => {
        }, error => {
          console.log()
        }
      )
  }

  initFormGroup() {
    this._activatedRoute.params.subscribe(async (param) => {
      const EmployeeId = param['id'];
      (
        this._employeeService.getEmployeeById(EmployeeId)).subscribe((res) => {
        if (res) {
          this.initEmployee = res;
          this.currentEmp();
          
        }
      })
    })

   
  }

  currentEmp(){
    this.formGroup = new FormGroup({
      "firstName": new FormControl(this.initEmployee?.firstName, [Validators.required]),
      "lastName": new FormControl(this.initEmployee?.lastName, [Validators.required]),
      "tz": new FormControl(this.initEmployee?.tz, [Validators.required, Validators.pattern('^[0-9]{9}$')]),
      "dateOfBirth": new FormControl(this.initEmployee?.dateOfBirth, [Validators.required]),
      "gander": new FormControl(this.initEmployee?.gender, [Validators.required]),
      "beginningOfWork": new FormControl(this.initEmployee?.beginningOfWork, [Validators.required]),
      "employeeRoles": new FormArray([])
      
      
    });
    this.showJob();
    this.jobDetailsFormArray = this.formGroup.get('employeeRoles') as FormArray;
  }


  get rolesFormArray() {
    return this.formGroup.get('employeeRoles') as FormArray;
  }

  removeThisJob(index: number) {
    this.rolesFormArray.removeAt(index);
  }

  addNewJob(){
    this.rolesFormArray?.push(new FormGroup({
      "jobTitle": new FormControl('', [Validators.required]),
      "isManagement": new FormControl(true,[Validators.required] ),
      "dateOfEntryToWork": new FormControl('' , [Validators.required])
    }));
  }

  showJob() {
    console.log(this.initEmployee)
    this.initEmployee?.employeeRoles?.forEach(role => {
      this.rolesFormArray.push(new FormGroup({
      "jobTitle": new FormControl(role?.roleId, [Validators.required]),
      "isManagement": new FormControl(role?.isManagement,[Validators.required] ),
      "dateOfEntryToWork": new FormControl(role?.DateOfEntryToWork , [Validators.required])
    }));
    })
    
  }

    // getAlljobTitles() {
    //   this._roleService.getAllRoles().subscribe(res => {
    //     this.jobTitles = res
    //   })
    // }

  onSubmit() {
    this._activatedRoute.params.subscribe(async (param) => {
      const fetchedEmpId = param['id'];
      console.log(fetchedEmpId);
      this._employeeService.updateEmployee(fetchedEmpId, this.formGroup.value).subscribe(res => {
      }, (err) => {
        console.log(err)
      })
      this.router.navigate(['/allEmployees'])

    })
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