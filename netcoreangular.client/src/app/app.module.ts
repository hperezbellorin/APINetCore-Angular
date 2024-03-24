import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';


import { InicioComponent } from './inicio/inicio.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { ClienteComponent } from './cliente/cliente.component';
import { LoginComponent } from './Login/Login.component';
import { ProductoComponent } from './Productos/Productos.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap'
import { Component } from '@angular/core';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    InicioComponent,
   // ClienteComponent,
    LoginComponent,
    ProductoComponent


  ],
  imports: [

    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    RouterModule.forRoot([
      { path: '', component: InicioComponent, pathMatch: 'full' },
      { path: 'inicio', component: InicioComponent },
     // { path: 'cliente', component: ClienteComponent },
      { path: 'login', component: LoginComponent },
      { path: 'Productos', component: ProductoComponent },

    ])

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
