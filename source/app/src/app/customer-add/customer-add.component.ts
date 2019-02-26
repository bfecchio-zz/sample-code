import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { ApiService } from '../api.service';
import { SocialSecurity } from '../_helpers/social-security.validator';
import { DatePipe } from '@angular/common';

function formatter(value: Date): String {
  var datePipe = new DatePipe("pt-BR");
  return datePipe.transform(value, 'yyyy-MM-dd');
}

@Component({
  selector: 'app-customer-add',
  templateUrl: './customer-add.component.html',
  styleUrls: ['./customer-add.component.scss']
})
export class CustomerAddComponent implements OnInit {
  submitted = false;
  registerForm: FormGroup;
  constructor(private formBuilder: FormBuilder, private router: Router, private apiService: ApiService) { }    

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      id: [''],
      name: ['', Validators.required],
      phones: [[]],
      addresses: [[]],
      birthday: ['', Validators.required],
      facebook: [],
      linkedIn: [],
      twitter: [],
      instagram: [],
      documentId: ['', Validators.required],
      socialSecurityId: ['', Validators.required]
    }, {
      validators: SocialSecurity('socialSecurityId')
    });
  }
  
  get f() { return this.registerForm.controls; }

  onSubmit() {   
    this.submitted = true;
    if (this.registerForm.invalid) return;

    this.apiService.createCustomer(this.registerForm.value)
      .subscribe(_ => this.router.navigate(['customers']));
  }
}
