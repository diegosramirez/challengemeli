from flask import request, json, Response, Blueprint
from ..models.ConfigurationModel import ConfigurationModel, ConfigurationSchema

configuration_api = Blueprint('configuration_api', __name__)
configuration_schema = ConfigurationSchema()


@configuration_api.route('/', methods=['POST'])
def create():
    req_data = request.get_json()

    configuration = ConfigurationModel(req_data)
    configuration.save()
    configuration_data = configuration_schema.dump(configuration)

    return custom_response({'configuration': configuration_data}, 201)


@configuration_api.route('/', methods=['DELETE'])
def delete():
    apps_in_db = ConfigurationModel.get_all_configurations()

    for x in apps_in_db:
        x.delete()

    return custom_response({'message': 'deleted'}, 204)


@configuration_api.route('/<int:app_id>', methods=['GET'])
def get_by_id(app_id):
    app_in_db = ConfigurationModel.get_configuration_by_id(app_id)

    if not app_in_db:
        return custom_response({'error': 'configuration not found'}, 404)

    data = configuration_schema.dump(app_in_db)

    return custom_response(data, 200)


@configuration_api.route('/', methods=['GET'])
def get_all():
    apps_in_db = ConfigurationModel.get_all_configurations()
    data = configuration_schema.dump(apps_in_db, many=True)
    return custom_response(data, 200)


def custom_response(res, status_code):
    return Response(
        mimetype="configuration/json",
        response=json.dumps(res),
        status=status_code
    )
