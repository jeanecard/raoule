import { Component, OnDestroy, OnInit } from '@angular/core';
import { ControlValueAccessor } from '@angular/forms';
import Map from 'ol/Map';
import View from 'ol/View';
import { HROpenLayerViewService } from '../../services/hropen-layer-view.service';
import * as olProj from 'ol/proj';
import { Subscription, first } from 'rxjs';
import { HRViewCoordinate } from '../../models/hrview-coordinate';
import { Coordinate } from 'ol/coordinate';

@Component({
  selector: 'app-hropen-layer-displayer',
  templateUrl: './hropen-layer-displayer.component.html',
  styleUrls: ['./hropen-layer-displayer.component.scss']
})
export class HROpenLayerDisplayerComponent implements ControlValueAccessor, OnInit, OnDestroy {

  public map: Map | null = null;
  private _subscriptions = new Subscription();
  private _nomPourTest = "HRTEST";

  constructor(private layerService: HROpenLayerViewService) {
    // Dummy.
  }

  ngOnDestroy(): void {
    this._subscriptions.unsubscribe();
    // on set la view origin ?
    // TODO
  }

  /**
* @description
* 1- Création de la vue
* 2- Branchement sur l'observable retournant le positionnement par défaut de la cartographie.
* 3- Branchement sur l'observable retournant les layers affichés (pilotés par ailleurs)
* @returns Nothing.
*/
  ngOnInit(): void {
    // 1-
    this.map = new Map({
      layers: [],
      target: 'ol-map'
    });
    // 2-
    this.initViewOrigin();
    // 3-
    this.plugLayers();
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

  /**
* @description
* 1- Souscription unique au positionnement par défaut de la cartographie.
* 2- Projection en EPSG:3857 si nécessaire (TODO : attention il faudrait voir si la carto est bien en EPSG:3857) 
* 3- Assignation de la vue à la map.
* @returns Nothing.
*/
  private initViewOrigin() {
    // 1-
    this.layerService.getViewsOrigin$().
      pipe(first()).
      subscribe(
        data => {
          let views= data.filter(item => item.key === this._nomPourTest);
          // Si j'ai qq chose dans les prefs c'est bon
          if(views?.length > 0){
            let center = views[0].origin;
            // 2-
            if (views[0]?.projection === 'EPSG:4326') {
              center = olProj.fromLonLat([views[0]?.origin[0], views[0]?.origin[1]], 'EPSG:3857');
            }
            // 3-
            const view: View = new View({
              center: center,
              zoom: views[0]?.zoom,
            });
            this.map?.setView(view);
  
          }
          else{

            //creation du hrviewOrigin
            const defaultView = new HRViewCoordinate();
            let viewCoord = new HRViewCoordinate();
            viewCoord.key = this._nomPourTest;
            let center : Coordinate |undefined;
            // 2-
            if (viewCoord.projection === 'EPSG:4326') {
              center = olProj.fromLonLat([viewCoord.origin[0], viewCoord.origin[1]], 'EPSG:3857');
            }            
            const view: View = new View({
              center: center,
              zoom: viewCoord.zoom,
            });
            this.map?.setView(view);
            //set de la vue
            // gros cochon refacto et TU à faire grouik grouik :-) + sur le on destro sauvegarder ta position et implménter le CVA pour setter le nom sur le modele
          }  
          // Sinon je fais le défaut
        });
  }

  /**
* @description
* 1- Souscription / enregistrement pour libération aux Layers disponibles pour affichage pour la cartogrpahie.
* 2- "Reset" des Layers existants et ajout des nouveaux
* 3- "Refresh" de la map
* @returns Nothing.
*/
  private plugLayers(): void {
    // 1-
    this._subscriptions.add(
      this.layerService.getDisplayedLayers$().
        subscribe(
          data => {
            // 2-
            this.map?.getLayers()?.clear();
            data.forEach(item => this.map?.addLayer(item));
            // 3-
            this.map?.changed();
          })
    );
  }
}


