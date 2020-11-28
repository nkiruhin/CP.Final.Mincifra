import {DefaultPortModelOptions} from '@projectstorm/react-diagrams';
import {NodeModel, NodeModelGenerics, NodeModelListener} from '@projectstorm/react-diagrams-core/';
import {DiagramModel} from '@projectstorm/react-diagrams-core/';

import { BaseModelOptions } from '@projectstorm/react-canvas-core';
import { Entity } from '../models/Entity';

import {ErdPortModel} from "./ErdPortModel";

export interface ErdNodeModelOptions extends BaseModelOptions {
	color?: string;
	table?: Entity
}
let portRegister = {};

export interface ErdNodeModelGenerics extends NodeModelGenerics {
	LISTENER: NodeModelListener;
	PARENT: DiagramModel;
}

export class ErdEntityModel<G extends ErdNodeModelGenerics = ErdNodeModelGenerics> extends NodeModel<G> {
	color: string;
	entity: Entity;
	protected ports: { [s: string]: ErdPortModel };

	constructor(options: ErdNodeModelOptions = {}) {
		super({
			...options,
			type: 'ts-custom-node'
		});
		this.color = options.color || 'red';
		this.entity = options.table || new Entity();

		let currentModel = this;
		let portName = ErdEntityModel.getPortName(this.entity,'in');

		// setup an in and out port
		portRegister[portName] = {};
		let portModelOptions: DefaultPortModelOptions = {
			in: true,
			name: portName
		};
		
		//portRegister[portName] = currentModel.addPort(
		//	new ErdPortModel(portModelOptions)
		//);

		portName = ErdEntityModel.getPortName(this.entity, 'out');

		// setup an in and out port
		portRegister[portName] = {};
		portModelOptions.in = false,
			portModelOptions.name = portName
		
		//portRegister[portName] = currentModel.addPort(
		//	new ErdPortModel(portModelOptions)
		//);
	}

	removePortByName(name : string):void
	{
		let ports : {[s:string] : ErdPortModel} = this.getPorts();
		for (let portsKey in ports) {
			if(ports.hasOwnProperty(portsKey))
			{
				let port : ErdPortModel = ports[portsKey];
				//console.log(port.getName(), name);
				//if(port.getName() === name)
				//{
				//	console.log('REMOVE!');
				//	port.removeLinks();
				//	this.removePort(port);
				//}
			}
		}
	}
	
	getPorts(): { [s: string]: ErdPortModel } {
		return this.ports;
	}
	static makePortName(entity:string, direction:string):string
	{
		return entity + '_' + direction;
	}
	static getPortName(entity: Entity, direction: string): string
	{
		return this.makePortName(Entity.name, direction);
	}
	static getPortFromRegister(portName):ErdPortModel
	{
		return portRegister[portName];
	}
	serialize() {
		return {
			...super.serialize(),
			color: this.color,
			table: this.entity,
		};
	}
	deserialize(event): void {
		super.deserialize(event);
		this.color = event.data.color;
		this.entity = event.data.entity;
	}
}
