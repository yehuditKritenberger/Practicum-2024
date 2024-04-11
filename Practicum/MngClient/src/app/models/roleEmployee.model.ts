export class RoleEmployee{
    
    roleId!: Number;
    isManagement!: boolean;
    DateOfEntryToWork!: Date;

    constructor(roleId: Number, isManagement: boolean, DateOfEntryToWork: Date) {
        this.roleId = roleId;
        this.isManagement = isManagement;
        this.DateOfEntryToWork = DateOfEntryToWork;
    }
}