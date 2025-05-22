import { Component, OnInit } from '@angular/core';
import { CourseService } from '../../../services/course.service';
import { Router } from '@angular/router';
import { ICourseResponse } from '../../../models/course.model';
import { FilterBase } from '../../../models/filter-base.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatTableModule } from '@angular/material/table';

@Component({
  selector: 'app-course-list',
  imports: [
    CommonModule,
    FormsModule,
    MatProgressBarModule,
    MatTableModule,
    MatPaginatorModule,
    MatButtonModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
  ],
  templateUrl: './course-list.component.html',
  styleUrl: './course-list.component.scss'
})
export class CourseListComponent implements OnInit {
  courses: ICourseResponse[] = [];
  total = 0;
  loading = false;

  filter: FilterBase = {
    search: '',
    sortBy: 'StartDate',
    sortDesc: true,
    page: 1,
    pageSize: 10,
  };

  constructor(private courseService: CourseService, private router: Router) {}

  ngOnInit(): void {
    this.loadCourses();
  }

  loadCourses(): void {
    this.loading = true;
    this.courseService.getAll(this.filter).subscribe(res => {
      this.loading = false;
      if (res.success && res.data) {
        this.courses = res.data.items;
        this.total = res.data.totalCount;
      }
    });
  }

  onDelete(id: number): void {
    if (confirm('Are you sure?')) {
      this.courseService.delete(id).subscribe(() => this.loadCourses());
    }
  }

  onEdit(id: number): void {
    this.router.navigate(['/form', id]);
  }

  onCreate(): void {
    this.router.navigate(['/form']);
  }
}

