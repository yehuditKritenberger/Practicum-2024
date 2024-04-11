import { RoleEmployee } from "./roleEmployee.model";

export class Employee{
    
    id!: Number;
    firstName!: string;
    lastName!: string;
    tz!: string;
    dateOfBirth!: Date;
    beginningOfWork!: Date;
    gender!: boolean;
    employeeRoles!: RoleEmployee[];

    constructor(id: Number, firstName: string, lastName: string, tz: string, dateOfBirth: Date, beginningOfWork: Date, gender: boolean, 
        employeeRoles: RoleEmployee[]){
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.tz = tz;
            this.dateOfBirth = dateOfBirth;
            this.beginningOfWork = beginningOfWork;
            this.gender = gender;
            this.employeeRoles = employeeRoles;
        }
}