
export class Project{
    constructor(
        public Id?: number,
        public ProjectName? : string,
        public DepartmentId?: number,
        public CategoryId?: number,
        public ExpireDate?: Date,
        public IsSupport?: boolean
         ){}
  } 
  export class Sprint{
    constructor(
        public  Id? : number,
        public  ProjectId? : number,
        public  SprintTitle? : string,
        public  StartDate?: string,
        public  EndDate?: string,
        public  Completed?: boolean,
        public  Goal? : string,
        public  PersonId? : number,
        public  IsStart?: boolean,
        public  IsSupport?: boolean,
        public SprintStartDate? : string,
        public SprintEndDate?:string

         ){}
  } 