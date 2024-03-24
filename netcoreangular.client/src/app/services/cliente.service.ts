import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Resultado } from '../modelos/resultado';
import { Cliente } from '../modelos/cliente';

@Injectable
  ({
    providedIn: 'root'
  })

export class ClienteService {
  url: string = 'http://localhost:5151/API/clientes/';
  constructor(private peticion: HttpClient) {

  }

  dameclientes(): Observable<Resultado> {
    return this.peticion.get<Resultado>(this.url);
  }

  agregarCliente(cliente: Cliente): Observable<Resultado> {
    return this.peticion.post<Resultado>(this.url, cliente);
  }

  modificarCliente(cliente: Cliente): Observable<Resultado> {
    return this.peticion.put<Resultado>(this.url, cliente);
  }

  bajaCliente(email: string): Observable<Resultado> {
    return this.peticion.delete<Resultado>(this.url + email);
  }

}
