import './main.css';
import {Renderer} from './renderer';
import {Table, ITable} from "./models/Table";
import {Relation} from "./models/Relation";
import {Message, Messenger} from "./helpers/Messenger";
import {Field} from "./models/Field";
import { ErdDiagramModel } from "./nodes/ErdDiagramModel";
import fetchApi from './services/fetcher';

console.log(location.search);
const url = "http://localhost:5000/api/Nodes/"



let model = new ErdDiagramModel();
Renderer.render(model);

interface IData {
	tables: ITable[],
	relations?: Relation[]
}


export const loadNodes = async (search: string) => {
	const response = await fetchApi(null, url + search , "GET");
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
loadNodes('');