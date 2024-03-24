import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Resultado } from '../modelos/resultado';

@Injectable
  ({
    providedIn: 'root'
  })

export class ProductoService {
  url: string = 'http://localhost:5151/API/productos/';
  constructor(private peticion: HttpClient) {

  }

  dameProductos(): Observable<Resultado> {
    return this.peticion.get<Resultado>(this.url);
  }

}
