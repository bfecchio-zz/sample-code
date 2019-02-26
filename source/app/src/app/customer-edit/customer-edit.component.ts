import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ApiService } from '../api.service';
import { SocialSecurity } from '../_helpers/social-security.validator';
import { DatePipe } from '@angular/common';

function formatter(value: Date): String {
  var datePipe = new DatePipe("pt-BR");
  return datePipe.transform(value, 'yyyy-MM-dd');
}

@Component({
  selector: 'app-customer-edit',
  templateUrl: './customer-edit.component.html',
  styleUrls: ['./customer-edit.component.scss']
})
export class CustomerEditComponent implements OnInit {
  submitted = false;  
  editForm: FormGroup;
  constructor(private formBuilder: FormBuilder, private router: Router, private route: ActivatedRoute, private apiService: ApiService) { }

  ngOnInit() {    
    let customerId = this.route.snapshot.params['id']

    if (!customerId) {
      alert('Oops... Ação inválida!')
      this.router.navigate(['customers'])
      
      return
    }

    this.editForm = this.formBuilder.group({
      id: ['', Validators.required],
      name: ['', Validators.required],
      phones: [],
      addresses: [],
      birthday: [''],
      facebook: [],
      linkedIn: [],
      twitter: [],
      instagram: [],
      documentId: ['', Validators.required],
      socialSecurityId: ['', Validators.required],
      dateCreated: [],
      dateUpdated: []
    },{
      validator: SocialSecurity('socialSecurityId')
    });

    this.apiService.getCustomer(customerId)
      .subscribe(data => {                
        this.editForm.setValue(data)
        this.editForm.patchValue({birthday: formatter(data.birthday)})
      });
  }

  delete() {
    if (confirm('Atenção!\nDeseja realmente exluir esse cliente?')){
      this.apiService.deleteCustomer(this.editForm.value)
        .subscribe(
          data => {
            alert('Registro excluído com sucesso!')
            this.router.navigate(['customers'])
          },
          error => {
            alert('Oops... Ocorreu um erro de comunicação com o servidor.')
          }
        )
    }        
  }

  get f() { return this.editForm.controls; }

  onSubmit() {
    this.submitted = true;    
    if (this.editForm.invalid) return;

    this.apiService.updateCustomer(this.editForm.value)
      .subscribe(
        data => {
          alert('Dados do cliente atualizados com sucesso!')
          this.router.navigate(['customers'])
        },
        error => {
          alert('Oops... Ocorreu um erro de comunicação com o servidor.')
        }
      )
  }
}
