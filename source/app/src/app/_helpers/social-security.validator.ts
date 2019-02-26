import { FormGroup } from '@angular/forms';

// custom validator to check that two fields match
export function SocialSecurity(controlName: string) {
    return (formGroup: FormGroup) => {
        const regex = /^[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}$/g;
        const control = formGroup.controls[controlName];
        
        if (control.errors && !control.errors.invalidSocialSecurity) {            
            return;
        }

        if (regex.test(control.value) == false) {
            control.setErrors({ invalidSocialSecurity: true });
        } else {
            control.setErrors(null);
        }
    }
}