import { Routes } from '@angular/router';
import { CourseListComponent } from './features/courses/course-list/course-list.component';
import { CourseFormComponent } from './features/courses/course-form/course-form.component';
import { AppComponent } from './app.component';

export const routes: Routes = [
//   { path: '', component: AppComponent, title: 'Home' },
  { path: '', component: CourseListComponent, title: 'List Courses', pathMatch: 'full' },
  { path: 'form', component: CourseFormComponent, title: 'Add Course' },
  { path: 'form/:id', component: CourseFormComponent, title: 'Update Course' }
];

