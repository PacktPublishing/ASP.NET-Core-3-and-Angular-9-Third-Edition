import { Component, Inject } from '@angular/core';
// import { HttpClient, HttpParams } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators, AbstractControl, AsyncValidatorFn } from '@angular/forms';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { BaseFormComponent } from '../base.form.component';

import { Country } from '../countries/country';
import { CountryService } from './country.service';

@Component({
  selector: 'app-country-edit',
  templateUrl: './country-edit.component.html',
  styleUrls: ['./country-edit.component.css']
})
export class CountryEditComponent
  extends BaseFormComponent {

  // the view title
  title: string;

  // the form model
  form: FormGroup;

  // the city object to edit or create
  country: Country;

  // the city object id, as fetched from the active route:
  // It's NULL when we're adding a new country,
  // and not NULL when we're editing an existing one.
  id?: number;

  constructor(
    private fb: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private countryService: CountryService) {
    super();
  }

  ngOnInit() {
    this.form = this.fb.group({
      name: ['',
        Validators.required,
        this.isDupeField("name")
      ],
      iso2: ['',
        [
          Validators.required,
          Validators.pattern(/[a-zA-Z]{2}/)
        ],
        this.isDupeField("iso2")
      ],
      iso3: ['',
        [
          Validators.required,
          Validators.pattern(/[a-zA-Z]{3}/)
        ],
        this.isDupeField("iso3")
      ]
    });

    this.loadData();
  }

  loadData() {

    // retrieve the ID from the 'id'
    this.id = +this.activatedRoute.snapshot.paramMap.get('id');
    if (this.id) {
      // EDIT MODE

      // fetch the country from the server
      this.countryService.get<Country>(this.id)
        .subscribe(result => {
          this.country = result;
          this.title = "Edit - " + this.country.name;

          // update the form with the country value
          this.form.patchValue(this.country);
        }, error => console.error(error));
    }
    else {
      // ADD NEW MODE

      this.title = "Create a new Country";
    }
  }

  onSubmit() {

    var country = (this.id) ? this.country : <Country>{};

    country.name = this.form.get("name").value;
    country.iso2 = this.form.get("iso2").value;
    country.iso3 = this.form.get("iso3").value;

    if (this.id) {
      // EDIT mode
      this.countryService
        .put<Country>(country)
        .subscribe(result => {

          console.log("Country " + country.id + " has been updated.");

          // go back to cities view
          this.router.navigate(['/countries']);
        }, error => console.error(error));
    }
    else {
      // ADD NEW mode
      this.countryService
        .post<Country>(country)
        .subscribe(result => {

          console.log("Country " + result.id + " has been created.");

          // go back to cities view
          this.router.navigate(['/countries']);
        }, error => console.error(error));
    }
  }

  isDupeField(fieldName: string): AsyncValidatorFn {
    return (control: AbstractControl): Observable<{ [key: string]: any } | null> => {

      var countryId = (this.id) ? this.id.toString() : "0";

      return this.countryService.isDupeField(
        countryId,
        fieldName,
        control.value)
        .pipe(map(result => {
          return (result ? { isDupeField: true } : null);
        }));
    }
  }
}
