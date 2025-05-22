import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ICourseRequest } from '../../../models/course.model';
import { CourseService } from '../../../services/course.service';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-course-form',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatCheckboxModule,
    MatButtonModule
  ],
  templateUrl: './course-form.component.html',
  styleUrl: './course-form.component.scss'
})
export class CourseFormComponent implements OnInit {
  form!: FormGroup;
  id?: number;
  isEdit = false;

  constructor(
    private fb: FormBuilder,
    private courseService: CourseService,
    private route: ActivatedRoute,
    public router: Router
  ) {}

  ngOnInit(): void {
    this.form = this.fb.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
      instructor: ['', Validators.required],
      startDate: ['', Validators.required],
      endDate: ['', Validators.required],
      isCompleted: [false]
    });

    this.route.paramMap.subscribe(params => {
      const idParam = params.get('id');
      if (idParam) {
        this.id = +idParam;
        this.isEdit = true;
        this.courseService.get(this.id).subscribe(res => {
          if (res.success && res.data) {
            this.form.patchValue(res.data);
          }
        });
      }
    });
  }

  onSubmit(): void {
    if (this.form.invalid) return;

    const data = this.form.value as ICourseRequest;
    const action = this.isEdit
      ? this.courseService.update(this.id!, data)
      : this.courseService.create(data);

    action.subscribe(() => this.router.navigate(['/']));
  }
}

