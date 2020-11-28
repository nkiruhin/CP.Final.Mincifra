import * as React from 'react';
import * as ReactDOM from 'react-dom';
import createEngine, {
    DagreEngine,
    DefaultLinkModel, DefaultNodeFactory,
    DiagramEngine, DiagramModel, PathFindingLinkFactory
} from '@projectstorm/react-diagrams';
import {ErdDiagramModel} from "./nodes/ErdDiagramModel";
import {ErdNodeModel} from './nodes/ErdNodeModel';
import {WorkspaceContainer} from "./WorkspaceContainer";
import {Table} from "./models/Table";
import {eventHandler} from "./nodes/EventHandler";
import {Field} from "./models/Field";
import {ErdNodeFactory} from "./nodes/ErdNodeFactory";
import {Settings} from "./Settings";

let engine = createEngine();
engine.getNodeFactories().registerFactory(new ErdNodeFactory());


export class Renderer {

    static domContentLoaded : boolean = false;
    static nodeIndex:number = 0;

    static render(model : DiagramModel): void {

        engine.setModel(model);

        document.addEventListener('DOMContentLoaded', () => {
            Renderer.domContentLoaded = true;
            ReactDOM.render(<WorkspaceContainer model={model} engine={engine}/>, document.querySelector('#application'));
        });
    }
    static addNode(model: ErdDiagramModel, table : Table, index):void
    {
        console.log('ERD', 'Renderer.addNode()', table, index);


        const nodeX = new ErdNodeModel({color: 'rgb(0,192,255)', table : table});
        nodeX.setPosition(index * 70, 50);
        model.addNode(nodeX);

        model.registerListener({
            eventDidFire: eventHandler('edit_model')
        });
    }

    static addLink(model:ErdDiagramModel, tableFrom:string, fieldFrom:string, tableTo:string, fieldTo:string):void
    {
        console.log('ERD', 'Renderer.addLink()', tableFrom, fieldFrom, tableTo, fieldTo);
        const pathfinding = engine.getLinkFactories().getFactory<PathFindingLinkFactory>(PathFindingLinkFactory.NAME);
        const portOut = ErdNodeModel.getPortFromRegister(ErdNodeModel.makePortName(tableFrom, fieldFrom, 'out'));
        const portTo = ErdNodeModel.getPortFromRegister(ErdNodeModel.makePortName(tableTo, fieldTo, 'in'));
        const link = new DefaultLinkModel();
        link.setSourcePort(portOut);
        link.setTargetPort(portTo);
        model.addLink(link);
    }
    static done(model : ErdDiagramModel)
    {

        console.log('ERD', 'Renderer.done()', model);

        engine.setModel(model);
        engine.repaintCanvas();

        engine
            .getLinkFactories()
            .getFactory<PathFindingLinkFactory>(PathFindingLinkFactory.NAME)
            .calculateRoutingMatrix();

        engine.repaintCanvas();

        setTimeout(() => {
            console.log('repaint');
            engine.repaintCanvas();
            ReactDOM.render(<WorkspaceContainer model={model} engine={engine}/>, document.querySelector('#application'));
            engine.repaintCanvas();
        }, 500)
    }
    static clear(model:ErdDiagramModel)
    {
        console.log('ERD', 'Renderer.clear()');

        model.getLinks().forEach((LinkModel) => {model.removeLink(LinkModel)});
        model.getNodes().forEach((NodeModel) => {model.removeNode(NodeModel)});
        engine.setModel(model);

    }
}

