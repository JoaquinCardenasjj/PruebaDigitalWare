import { DatePipe } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { TransversalService } from 'src/app/services/TransversalService';

import swalAlert from 'sweetalert2';
import { DetalleCompraModel, FacturaModel } from '../facturacion.model';
@Component({
  selector: 'app-create-facturaciones',
  templateUrl: './create-facturaciones.component.html',
  styleUrls: ['./create-facturaciones.component.css']
})
export class CreateFacturacionesComponent implements OnInit {
  @Input()
  accion: string = "";
  fecha: any;
  @Input()
  listaEmpleados: any = [];
  listaProductos: any = [];
  listaDetalleCompra: any = [];
  compra = {
    clienteId: 0,
    fechaCompra: new Date(),
  }
  hireDateOptions = {
    disabled: true
  }
  submitButtonOptions = {
    text: "Enviar facturaciòn",
    useSubmitBehavior: true
  }
  handleSubmit = function (e: any) {
    debugger;
    setTimeout(() => {
      alert("Submitted");
    }, 1000);

    e.preventDefault();
  }
  constructor(private _TransversalService: TransversalService, public activeModal: NgbActiveModal,
    public datepipe: DatePipe) { }

  ngOnInit(): void {


    this.cargarEmpleado();
    this.cargarProductos();

  }
  closeModal() {
    this.activeModal.close();
  }
  onFormSubmit(event: any): void {
    debugger;
    let listaDetalleCompraModel: Array<DetalleCompraModel> = [];
    if (this.listaDetalleCompra.length == 0) {
      swalAlert.fire('Error...', 'Debe agregar almenos un registro en el detalle de la compra', 'error');
      return;
    }
    this.listaDetalleCompra.forEach((element: any) => {
      let inputDetalleC = new DetalleCompraModel(0, element.productoId, 0, Number(element.cantidadComprada), 0, "");
      listaDetalleCompraModel.push(inputDetalleC);
    });
    let input = new FacturaModel(0, this.compra.fechaCompra, this.compra.clienteId, "", listaDetalleCompraModel, 0);
    this._TransversalService.generarFacturacion(input).subscribe((res: any) => {
      debugger;
      swalAlert.fire('Registro exitoso...', res.mensajeResponse, 'success');
      this.activeModal.dismiss('OK');

    });

  }

  updateModel(accion: string) {
    this._TransversalService.editActivity(null).subscribe((res: any) => {

      swalAlert.fire('Registro exitoso...', res.mensajeResponse, 'success');
      this.activeModal.dismiss('OK');

    });
  }
  cargarEmpleado() {
    this._TransversalService.getClients().subscribe((res: any) => {

      this.listaEmpleados = res.objetoResultado;
    });
  }

  cargarProductos() {
    this._TransversalService.getProducts().subscribe((res: any) => {
      debugger;
      this.listaProductos = res.objetoResultado;
    });
  }


  onValueChanged(e: any) {
    this.compra.clienteId = e.value;
    console.log(e.previousValue);
    console.log(e.value);
  }

}
