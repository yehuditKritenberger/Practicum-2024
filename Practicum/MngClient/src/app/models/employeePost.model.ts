import { RoleEmployee } from "./roleEmployee.model";

export class EmployeePost{
    
    
    firstName!: string;
    lastName!: string;
    tz!: string;
    dateOfBirth!: Date;
    beginningOfWork!: Date;
    gender!: boolean;
    employeeRoles!: RoleEmployee[];

    constructor( firstName: string, lastName: string, tz: string, dateOfBirth: Date, beginningOfWork: Date, gender: boolean, 
        employeeRoles: RoleEmployee[]){
           
            this.firstName = firstName;
            this.lastName = lastName;
            this.tz = tz;
            this.dateOfBirth = dateOfBirth;
            this.beginningOfWork = beginningOfWork;
            this.gender = gender;
            this.employeeRoles = employeeRoles;
        }
}