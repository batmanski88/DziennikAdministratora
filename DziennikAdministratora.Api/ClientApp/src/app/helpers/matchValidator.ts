import {NG_VALIDATORS, Validator, Validators, AbstractControl, ValidatorFn} from '@angular/forms';
import { Directive, forwardRef, Attribute } from '@angular/core';

@Directive({
    // tslint:disable-next-line:directive-selector
    selector: '[equalValidate][formControlName],[equalValidate][formControl],[equalValidate][ngModel]',
    providers: [
        {
            provide: NG_VALIDATORS,
            useExisting: forwardRef(() => EqualValidator),
            multi: true
        }
    ]
})

export class EqualValidator implements Validator {

    validator: ValidatorFn;
    constructor(@Attribute('equalValidate') public equalValidate: string) { }

    validate(abControl: AbstractControl): { [key: string]: any } {
        // Get self value.
        // tslint:disable-next-line:prefer-const
        let val = abControl.value;

        // Get control value.
        // tslint:disable-next-line:prefer-const
        let cValue = abControl.root.get(this.equalValidate);

        // value not equal
        // tslint:disable-next-line:curly
        if (cValue && val !== cValue.value) return {
            equalValidate: false
        // tslint:disable-next-line:semicolon
        }

        return null;
    }
}
