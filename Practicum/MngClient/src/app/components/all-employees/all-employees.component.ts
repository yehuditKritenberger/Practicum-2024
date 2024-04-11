import { Component, OnInit } from '@angular/core';
import { Employee } from '../../models/employee.model';
import { Router } from '@angular/router';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { EmployeeService } from '../../services/employee.service';
import { MatDividerModule } from '@angular/material/divider';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { Subscription, filter } from 'rxjs';
import * as XLSX from 'xlsx';
import { AddEmployeeComponent } from '../add-employee/add-employee.component';
import { CommonModule } from '@angular/common';
import { EmployeePost } from '../../models/employeePost.model';
import { EditEmployeeComponent } from '../edit-employee/edit-employee.component';

@Component({
  selector: 'app-all-employees',
  standalone: true,

  imports: [CommonModule, MatTableModule, MatIconModule, MatDialogModule, MatButtonModule,
    MatDividerModule, MatFormFieldModule, MatInputModule],
  templateUrl: './all-employees.component.html',
  styleUrl: './all-employees.component.scss'
})

export class AllEmployeesComponent implements OnInit {

  ELEMENT_DATA: Employee[] = [];
  displayedColumns: string[] = [
    'firstName',
    'lastName',
    'tz',
    'dateOfBirth',
    'additionalActions'
  ]
  employees!: Employee[]
  dataSource = new MatTableDataSource<Employee>();
  constructor(private router: Router, private _employeeService: EmployeeService, public dialog: MatDialog) {

  }
  ngOnInit() {
    this.getEmployeesList();
  }

  getEmployeesList() {
    this._employeeService.getAllEmployees().subscribe(res => {
      this.dataSource.data = res
      console.log(this.employees)
    })
  }
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  exportToExcel() {
    this._employeeService.getAllEmployees().subscribe(data => {
      const workbook = XLSX.utils.book_new();
      const worksheet = XLSX.utils.json_to_sheet(data);
      XLSX.utils.book_append_sheet(workbook, worksheet, 'Employees');
      XLSX.writeFile(workbook, 'employees.xlsx');
    });
  }
  addEmployee() {
    this.router.navigate(['/addEmployee'])
  }

  editEmployee(id: Number) {
    this.router.navigate(['/editEmployee', id])
  }

  delete(id: Number) {
    this._employeeService.deleteEmployee(id).subscribe(res => {
      this.dataSource = res
    }, (err) => {
      console.log(err)
    })
    this.getEmployeesList();

  }

}
