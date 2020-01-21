import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
    template: ''
})  
export class BaseFormComponent {

    // the form model
    form: FormGroup;

    constructor() {
    }

    // retrieve a FormControl
    getControl(name: string) {
        return this.form.get(name);
    }

    // returns TRUE if the FormControl is valid
    isValid(name: string) {
        var e = this.getControl(name);
        return e && e.valid;
    }

    // returns TRUE if the FormControl has been changed
    isChanged(name: string) {
        var e = this.getControl(name);
        return e && (e.dirty || e.touched);
    }

    // returns TRUE if the FormControl is raising an error,
    // i.e. an invalid state after user changes
    hasError(name: string) {
        var e = this.getControl(name);
        return e && (e.dirty || e.touched) && e.invalid;
    }
}
