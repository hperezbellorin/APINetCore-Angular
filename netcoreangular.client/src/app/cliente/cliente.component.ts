import { Component, Input,  OnInit, TemplateRef, ViewChild } from '@angular/core';

import { Cliente } from '../modelos/cliente';
import { ClienteService } from '../services/cliente.service';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import '@angular/localize/init';
@Component({
  selector: 'app-cliente-component',
  templateUrl: './cliente.component.html'
})


export class ClienteComponent {

  altaForm: FormGroup;
  enviado = false;
  resultadoPeticion: string | undefined;;
  @ViewChild("myModalInfo", { static: false }) myModalInfo: TemplateRef<any> 

  constructor(private servicioCliente: ClienteService, private formBuilder: FormBuilder,
    private modalService: NgbModal, private altaForm1: FormGroup,private myModalInfo1: TemplateRef<any>) {
    this.altaForm = altaForm1;
    this.myModalInfo = myModalInfo1;

  }

  ngOnInit(): void {
    this.altaForm = this.formBuilder.group({
      nombre: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      pass: ['', Validators.required]
    })
  }

  get f(): { [key: string]: AbstractControl } {
    return this.altaForm.controls;
  }


  public Alta() {
    this.enviado = true;
    if (this.altaForm.invalid) {
      console.log("Invalido");
      return;
    }

    console.log("valido");

    let cliente: Cliente =
    {
      nombre: this.altaForm.controls['nombre'].value,
      email: this.altaForm.controls['email'].value,
      pass: this.altaForm.controls['pass'].value
    };

    this.servicioCliente.agregarCliente(cliente).subscribe(res => {
      if (res.error != null && res.error != '')
        this.resultadoPeticion = res.texto;
      else
        this.resultadoPeticion = "Cliente dado de alta correctamente.Inicie sesión";

      this.modalService.open(this.myModalInfo);
    });



  }


}
