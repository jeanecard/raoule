import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { HRViewCoordinate } from '../models/hrview-coordinate';
import Layer from 'ol/layer/Layer';
import TileLayer from 'ol/layer/Tile';
import OSM from 'ol/source/OSM';

@Injectable({
  providedIn: 'root'
})
export class HROpenLayerViewService {
  
  private mViewsOrigin = new BehaviorSubject<HRViewCoordinate[]>([]);
  private mDisplayedLayers = new BehaviorSubject<Layer[]>([]);

  constructor() { }

  public getViewsOrigin$() : Observable<HRViewCoordinate[]>{
    return this.mViewsOrigin.asObservable();
  }

  public getDisplayedLayers$() : Observable<Layer[]>{
    return this.mDisplayedLayers.asObservable();
  }
  
  public loadAllCartogrphieConfiguration(): void{
    this.loadViewsOrigin();
    this.loadLayersPreferences();
  }

  public saveViewOrigin(value: HRViewCoordinate): void {
    if (value) {
      const rawValues = localStorage.getItem("HRViewOrigin");
      if(rawValues){
        let coords : HRViewCoordinate[] = JSON.parse(rawValues);  
        let candidateCoords = coords.filter(item => item.key === value.key);
        if(candidateCoords.length > 0){
          candidateCoords[0] = value;
        }else{
          coords.push(value);
        }
        localStorage.setItem("HRViewOrigin", JSON.stringify(coords));
        this.mViewsOrigin.next(coords); // TO FAUX        
      }
    }
  }

  private loadViewsOrigin(): void {
    const center = this.getDefaultValue();
    if (localStorage == null || localStorage == undefined) {
      this.mViewsOrigin.next([center]);
    }
    else{
      const values = localStorage.getItem("HRViewOrigin");
      if(values !== undefined && values !== null){
        this.mViewsOrigin.next(JSON.parse(values));
      }else{
        this.mViewsOrigin.next([center]);
      } 
    }
  }

  private getDefaultValue(): HRViewCoordinate {
    return new HRViewCoordinate();
  }

  private loadLayersPreferences(): void {
    // première version on a juste un seul layer pour la carto. On sauve encore rien en local storage
    this.mDisplayedLayers.next([new TileLayer({source: new OSM() })]);
    }
}
