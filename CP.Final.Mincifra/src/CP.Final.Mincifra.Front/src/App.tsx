import React from 'react';
import ReactDOM from 'react-dom';
import './main.css';
import { Renderer } from './renderer';
import { Table, ITable } from "./models/Table";
import { Relation } from "./models/Relation";
import { Message, Messenger } from "./helpers/Messenger";
import { Field } from "./models/Field";
import { ErdDiagramModel } from "./nodes/ErdDiagramModel";

const queryString = require('query-string');


//console.log(location.search);
//const getVariables = queryString.parse(location.search);



let model = new ErdDiagramModel();
Renderer.render(model);
// getVariables.schema points to the schema API, for instance 'http://api.overheid.demo.novum.nuidev.nl/v2/schema.json'

interface IData {
	tables: ITable[],
	relations?: Relation[]
}

let data: IData = {
	tables: [
		{
			name: "6e6dcd3b-0917-48f3-873e-4b9f6425fac9",
			is_persistent: false,
			title: "Физическое Лицо",
			api_description: "Налоговый кодекс Российской Федерации (часть первая) от 31.07.1998 N 146-ФЗ (ред. от 27.12.2019) (с изм. и доп., вступ. в силу с 01.01.2020)",
			is_node: false,
			fields: [{
				id: 1n,
				table_name: "6e6dcd3b-0917-48f3-873e-4b9f6425fac9",
				type: "VARCHAR",
				name: "Id",
				icon: "field",
				label: "Id",
				is_foreign_key: true,
				primary: 1,
				auto_increment: true,
				form_type: "",
				required: true
			}, {
				id: 1n,
				table_name: "6e6dcd3b-0917-48f3-873e-4b9f6425fac9",
				type: "INTEGER",
				name: "Code",
				icon: "field",
				label: "Code",
				is_foreign_key: false,
				primary: 1,
				auto_increment: true,
				form_type: "",
				required: false
			}]
		},
		{
			name: "d5068d89-445c-4854-a1a5-4b583eb30c34",
			is_persistent: false,
			title: "Медицинская Организация",
			api_description: "Налоговый кодекс Российской Федерации (часть первая) от 31.07.1998 N 146-ФЗ (ред. от 27.12.2019) (с изм. и доп., вступ. в силу с 01.01.2020)",
			is_node: true,
			fields: [{
				id: 1n,
				table_name: "d5068d89-445c-4854-a1a5-4b583eb30c34",
				type: "",
				name: "Id",
				icon: "field",
				label: "",
				is_foreign_key: true,
				primary: 1,
				auto_increment: true,
				form_type: "",
				required: true
			}]
		},
		{
			name: "591336ee-8702-4c7b-9f96-6b1fa00a8326",
			is_persistent: false,
			title: "ЮридическоеЛицо",
			api_description: "Гражданский кодекс Российской Федерации (часть первая)",
			is_node: true,
			fields: [{
				id: 1n,
				table_name: "591336ee-8702-4c7b-9f96-6b1fa00a8326",
				type: "",
				name: "Id",
				icon: "field",
				label: "",
				is_foreign_key: true,
				primary: 1,
				auto_increment: true,
				form_type: "",
				required: true
			}]
		},
	],
	relations: [{
		from_field: "Id",
		from_model: "6e6dcd3b-0917-48f3-873e-4b9f6425fac9",
		to_field: "Id",
		to_model: "d5068d89-445c-4854-a1a5-4b583eb30c34",
		on_delete: null,
		on_update: null
	},
	{
		from_field: "Id",
		from_model: "591336ee-8702-4c7b-9f96-6b1fa00a8326",
		to_field: "Id",
		to_model: "d5068d89-445c-4854-a1a5-4b583eb30c34",
		on_delete: null,
		on_update: null
	}]
}


let loadNodes = (data: IData) => {
	//fetch("shema")
	//	.then(res => res.json())
	//	.then(
	//		(json) => {
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

	//	}
	//);
};


export default () => {

	return (
		loadNodes(data)
  );
};
