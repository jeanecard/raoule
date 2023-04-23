import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { HRViewCoordinate } from '../models/hrview-coordinate';

@Injectable({
  providedIn: 'root'
})
export class HROpenLayerViewService {
  private mViewOrigin = new BehaviorSubject<HRViewCoordinate>(new HRViewCoordinate());

  constructor() { }

  getViewOrigin$() : Observable<HRViewCoordinate>{
    return this.mViewOrigin.asObservable();
  }

  public loadViewOrigin(): void {
    const center = this.getDefaultValue();
    if (localStorage == null || localStorage == undefined) {
      this.mViewOrigin.next(center);
    }

    const lat = localStorage.getItem("HRViewOrigin.lat");
    const lon = localStorage.getItem("HRViewOrigin.lon");
    const projection = localStorage.getItem("HRViewOrigin.projection");
    const zoom = localStorage.getItem("HRViewOrigin.zoom");

    if(lon !== undefined && lon !== null)
    {
      center.origin[0] = Number(lon)
    }

    if(lat !== undefined  && lat !== null)
    {
      center.origin[1] = Number(lat)
    }

    if(zoom !== undefined  && zoom !== null)
    {
      center.zoom = Number(zoom);
    }
    if(projection !== undefined && projection !== null)
    {
      center.projection = projection;
    }
    this.mViewOrigin.next(center);
  }

  public saveViewOrigin(value: HRViewCoordinate): void {
    if (value) {
      localStorage.setItem("HRViewOrigin.lon", value.origin[0].toString());
      localStorage.setItem("HRViewOrigin.lat", value.origin[1].toString());
      localStorage.setItem("HRViewOrigin.zoom", value.zoom.toString());
      localStorage.setItem("HRViewOrigin.projection", value.projection);
    }
  }

  private getDefaultValue(): HRViewCoordinate {
    return new HRViewCoordinate();
  }
}
