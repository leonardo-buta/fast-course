import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';
import { HomeComponent } from './home/home.component';
import { UsersComponent } from './users/users.component';
import { TenantsComponent } from './tenants/tenants.component';
import { RolesComponent } from 'app/roles/roles.component';
import { ChangePasswordComponent } from './users/change-password/change-password.component';
import { CoursesComponent } from './courses/courses.component';
import { CreateCourseComponent } from './courses/create-course/create-course.component';
import { QuestionsComponent } from './questions/questions.component';
import { CreateQuestionComponent } from './questions/create-question/create-question.component';
import { VideoLessonsComponent } from './video-lessons/video-lessons.component';
import { CreateVideoLessonComponent } from './video-lessons/create-video-lesson/create-video-lesson.component';
import { CreateCertificateComponent } from './certificates/create-certificate/create-certificate.component';
import { CertificatesComponent } from './certificates/certificates.component';
import { TutorialsComponent } from './tutorials/tutorials.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: AppComponent,
                children: [
                    { path: 'home', component: HomeComponent,  canActivate: [AppRouteGuard] },
                    { path: 'users', component: UsersComponent, data: { permission: 'Pages.Users' }, canActivate: [AppRouteGuard] },
                    { path: 'roles', component: RolesComponent, data: { permission: 'Pages.Roles' }, canActivate: [AppRouteGuard] },
                    { path: 'tenants', component: TenantsComponent, data: { permission: 'Pages.Tenants' }, canActivate: [AppRouteGuard] },
                    { path: 'update-password', component: ChangePasswordComponent, canActivate: [AppRouteGuard] },
                    { path: 'courses', component: CoursesComponent, canActivate: [AppRouteGuard] },
                    { path: 'create-course', component: CreateCourseComponent, canActivate: [AppRouteGuard] },
                    { path: 'questions', component: QuestionsComponent, canActivate: [AppRouteGuard] },
                    { path: 'create-question', component: CreateQuestionComponent, canActivate: [AppRouteGuard] },
                    { path: 'video-lessons', component: VideoLessonsComponent, canActivate: [AppRouteGuard] },
                    { path: 'create-video-lesson', component: CreateVideoLessonComponent, canActivate: [AppRouteGuard] },
                    { path: 'certificates', component: CertificatesComponent, canActivate: [AppRouteGuard] },
                    { path: 'create-certificate', component: CreateCertificateComponent, canActivate: [AppRouteGuard] },
                    { path: 'tutorials', component: TutorialsComponent, canActivate: [AppRouteGuard] }
                ]
            }
        ])
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }
