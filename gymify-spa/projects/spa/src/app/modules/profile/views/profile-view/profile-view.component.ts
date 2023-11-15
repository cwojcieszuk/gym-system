import { Component, OnInit } from '@angular/core';
import { NonNullableFormBuilder, Validators } from '@angular/forms';
import { ProfileFacade } from '../../+state/profile.facade';
import { BaseComponent } from '../../../../shared/components/base.component';
import { filter } from 'rxjs';
import { ImageService } from '../../../../shared/services/image.service';
import { AuthFacade } from '../../../../core/auth/+state/auth.facade';
import { DictionariesFacade } from '../../../../core/dictionaries-state/dictionaries.facade';

@Component({
  selector: 'gym-profile-view',
  templateUrl: './profile-view.component.html',
  styleUrls: ['./profile-view.component.scss'],
})
export class ProfileViewComponent extends BaseComponent implements OnInit {
  readonly form = this.fb.group({
    firstName: this.fb.control<string>('', Validators.required),
    lastName: this.fb.control<string>('', Validators.required),
    birthDate: this.fb.control<Date | null>(null, Validators.required),
    email: this.fb.control<string>('', Validators.required),
    login: this.fb.control<string>('', Validators.required),
    password: this.fb.control<string>(''),
    newPassword: this.fb.control<string>(''),
    confirmPassword: this.fb.control<string>('')
  });

  readonly coachForm = this.fb.group({
    description: this.fb.control<string>(''),
    categoryId: this.fb.control<number[]>([]),
  });

  imgSrc: string | ArrayBuffer | null = null;
  image: any;

  constructor(
    private fb: NonNullableFormBuilder,
    public profileFacade: ProfileFacade,
    private imgService: ImageService,
    public authFacade: AuthFacade,
    public dictionariesFacade: DictionariesFacade
  ) {
    super();
  }

  ngOnInit(): void {
    this.profileFacade.fetchUserData();
    this.dictionariesFacade.fetchCoachCategories();

    this.observe(this.profileFacade.user$)
      .pipe(filter(Boolean))
      .subscribe(value => {
        this.form.patchValue({
          firstName: value.firstName,
          lastName: value.lastName,
          login: value.login,
          email: value.email,
          birthDate: value.birthDate,
        });

        this.image = this.imgService.getJpeg(value.avatar);

        if (value.description) {
          this.coachForm.controls.description.patchValue(value.description);
        }

        this.coachForm.controls.categoryId.patchValue(value.categoryId);
      });
  }

  save(): void {
    this.profileFacade.updateUserData({
      firstName: this.form.controls.firstName.value,
      lastName: this.form.controls.lastName.value,
      login: this.form.controls.login.value,
      email: this.form.controls.email.value,
      birthDate: this.form.controls.birthDate.value!,
    });
  }

  updateUserPassword(): void {
    this.profileFacade.updateUserPassword({
      password: this.form.controls.password.value,
      newPassword: this.form.controls.newPassword.value,
      confirmPassword: this.form.controls.confirmPassword.value,
    });
  }

  readURL(event: any): void {
    if (event.target.files) {
      const file: File = event.target.files[0];

      this.profileFacade.setAvatar(file);
      const reader = new FileReader();
      reader.onload = e => this.imgSrc = reader.result;
      reader.readAsDataURL(file);
    }
  }

  saveDescription(): void {
    this.profileFacade.updateCoachDescription(this.coachForm.controls.description.value, this.coachForm.controls.categoryId.value);
  }
}
