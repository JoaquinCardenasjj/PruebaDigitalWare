import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, map, Observable, retry, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { constansts } from '../constans';
import { FacturaModel } from '../facturaciones/facturacion.model';

@Injectable({
    providedIn: 'root'
})
export class TransversalService {
    constructor(private http: HttpClient) { }


    private errorHandl(error: any) {
        let errorMessage = '';
        if (error.error instanceof ErrorEvent) {
            errorMessage = error.error.message;
        } else {
            errorMessage = `Error code: ${error.status}\nMessage:${error.message}`;

        }
        return throwError(errorMessage);
    }

    getCompras(): Observable<any> {
        return this.http.get(`${environment.backPruebaDigitalWare}/${constansts.compra}/${constansts.consultar}`).pipe(
            map((res) => res as any),
            retry(2),
            catchError(this.errorHandl)
        );
    }
    getClients(): Observable<any> {
        return this.http.get(`${environment.backPruebaDigitalWare}/${constansts.cliente}/${constansts.consultar}`).pipe(
            map((res) => res as any),
            retry(2),
            catchError(this.errorHandl)
        );
    }
    getProducts(): Observable<any> {
        return this.http.get(`${environment.backPruebaDigitalWare}/${constansts.producto}/${constansts.consultar}`).pipe(
            map((res) => res as any),
            retry(2),
            catchError(this.errorHandl)
        );
    }
    editActivity(actividad: any): Observable<any> {

        return this.http.put(`${environment.backPruebaDigitalWare}/${constansts.compra}/${actividad.idActividad}`, actividad).pipe(
            map((res) => res as any),
            retry(2),
            catchError(this.errorHandl)
        );
    }

    generarFacturacion(input: FacturaModel): Observable<any> {
        return this.http.post(`${environment.backPruebaDigitalWare}/${constansts.compra}/${constansts.generarFacturacion}`, input).pipe(
            map((res) => res as any),
            retry(2),
            catchError(this.errorHandl)
        );

    }
    deleteActivity(id: any): Observable<any> {
        return this.http.delete(`${environment.backPruebaDigitalWare}/${constansts.compra}/${id}`).pipe(
            map((res) => res as any),
            retry(2),
            catchError(this.errorHandl)
        );
    }
}