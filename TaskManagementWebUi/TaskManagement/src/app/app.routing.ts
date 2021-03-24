import { Routes, RouterModule } from "@angular/router";
import { HomeComponent } from "./Home/Home.Component";
import { ProjectComponent } from "./Home/project/project.component";
import { SprintComponent } from "./Home/sprint/sprint.component";
import { loginComponent } from "./Login/Login.component";
import { NotFoundComponent } from "./Login/NotFound.component";
import { AuthGuard } from "./Service/auth.guard";

const routes: Routes = [
    { path: "login", component: loginComponent},
    { path: "Home", component: HomeComponent,  canActivate: [AuthGuard],
        children: [
                        // { path: '', redirectTo: 'Project', pathMatch: 'full' },
                        { path: 'Project', component: ProjectComponent },
                        { path: 'Sprint', component: SprintComponent }
                 ]
    },
    { path: "", redirectTo: "Home", pathMatch: "full" },
    { path: "**", component: NotFoundComponent }
    ]
    
    
    export const routing = RouterModule.forRoot(routes);