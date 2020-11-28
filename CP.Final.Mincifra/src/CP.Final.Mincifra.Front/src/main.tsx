import './main.css';
import {Renderer} from './renderer';
import {Table, ITable} from "./models/Table";
import {Relation} from "./models/Relation";
import {Message, Messenger} from "./helpers/Messenger";
import {Field} from "./models/Field";
import { ErdDiagramModel } from "./nodes/ErdDiagramModel";
import fetchApi from './services/fetcher';

console.log(location.search);
const url = "http://localhost:57679/api/Nodes"



let model = new ErdDiagramModel();
Renderer.render(model);

interface IData {
	tables: ITable[],
	relations?: Relation[]
}


let loadNodes = async () => {
	const response = await fetchApi(null, url, "GET");
	let data = response.data as IData;
	Renderer.clear(model);

	data.tables.forEach((table: Table, index) => {
		Renderer.addNode(model, table, index);
		Renderer.nodeIndex = index;
	});

	data.relations.forEach((relation: Relation) => {
		Renderer.addLink(model, relation.from_model, relation.from_field, relation.to_model, relation.to_field);
	});

	setTimeout(() => {
		Renderer.done(model);
	}, 100);

};
loadNodes();

//console.log("Register model added listener");
//Messenger.onReceive('model_added', (message : Message<Table>) => {
//	Renderer.nodeIndex++;
//	Renderer.addNode(model, Table.fromJson(message.content), Renderer.nodeIndex);
//});


//console.log("Register property added listener");
//Messenger.onReceive('property_added', (message : Message<Field>) => {
//	console.log("Messenger.onReceive().property_added");
//	console.log("\t", JSON.stringify(message.content));

//	console.log("erd-tool -> property_added -> " + JSON.stringify(message.content));
//	Renderer.addProperty(model, Field.fromJson(message.content));
//	Renderer.done(model);
//});

//Messenger.onReceive('property_deleted', (message : Message<Field>) => {
//	console.log("Messenger.onReceive().property_deleted");
//	console.log("\t", JSON.stringify(message.content));
//	// loadNodes();
//	Renderer.removeField(model, Field.fromJson(message.content));
//});
