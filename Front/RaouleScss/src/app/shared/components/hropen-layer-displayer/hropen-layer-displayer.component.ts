import { Component, OnDestroy, OnInit } from '@angular/core';
import { ControlValueAccessor } from '@angular/forms';
import Map from 'ol/Map';
import View from 'ol/View';
import TileLayer from 'ol/layer/Tile';
import OSM from 'ol/source/OSM';
import { HROpenLayerViewService } from '../../services/hropen-layer-view.service';
import * as olProj from 'ol/proj';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-hropen-layer-displayer',
  templateUrl: './hropen-layer-displayer.component.html',
  styleUrls: ['./hropen-layer-displayer.component.scss']
})
export class HROpenLayerDisplayerComponent implements ControlValueAccessor, OnInit, OnDestroy{
  
  public map: Map | null = null;
  private _subscriptions = new Subscription();


  constructor(private layerService : HROpenLayerViewService){
  }
  ngOnDestroy(): void {
    this._subscriptions.unsubscribe();
  }

  ngOnInit(): void {
    this._subscriptions.add(
      this.layerService.getViewOrigin$().subscribe(data => {
      let center = data.origin;
      if(data.projection === 'EPSG:4326')
      {
        center = olProj.fromLonLat([data.origin[0], data.origin[1]], 'EPSG:3857');
      }
      this.map = new Map({
        view: new View({
          center: center,
          zoom: data.zoom,
        }),
        layers: [
          new TileLayer({
            source: new OSM(),
          }),
        ],
        target: 'ol-map'
      });
    })
    );
  }
  writeValue(obj: any): void {
    throw new Error('Method not implemented.');
  }
  registerOnChange(fn: any): void {
    throw new Error('Method not implemented.');
  }
  registerOnTouched(fn: any): void {
    throw new Error('Method not implemented.');
  }
  setDisabledState?(isDisabled: boolean): void {
    throw new Error('Method not implemented.');
  }

}
