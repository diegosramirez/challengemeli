from flask import request, json, Response, Blueprint
from ..models.AlgorithmModel import AlgorithmModel, AlgorithmSchema

algorithm_api = Blueprint('algorithm_api', __name__)
algorithm_schema = AlgorithmSchema()


@algorithm_api.route('/', methods=['POST'])
def create():
    req_data = request.get_json()

    data = algorithm_schema.load(req_data)

    app_in_db = AlgorithmModel.get_algorithm_by_name(data.get('name'))

    if app_in_db:
        message = {
            'error': 'algorithm already exist, please supply another algorithm name'}
        return custom_response(message, 400)

    algorithm = AlgorithmModel(data)
    algorithm.save()
    algorithm_data = algorithm_schema.dump(algorithm)

    return custom_response({'algorithm': algorithm_data}, 201)


@algorithm_api.route('/', methods=['DELETE'])
def delete():
    apps_in_db = AlgorithmModel.get_all_algorithms()

    for x in apps_in_db:
        x.delete()

    return custom_response({'message': 'deleted'}, 204)


@algorithm_api.route('/<int:app_id>', methods=['GET'])
def get_by_id(app_id):
    app_in_db = AlgorithmModel.get_algorithm_by_id(app_id)

    if not app_in_db:
        return custom_response({'error': 'algorithm not found'}, 404)

    data = algorithm_schema.dump(app_in_db)

    return custom_response(data, 200)


@algorithm_api.route('/', methods=['GET'])
def get_all():
    apps_in_db = AlgorithmModel.get_all_algorithms()
    data = algorithm_schema.dump(apps_in_db, many=True)
    return custom_response(data, 200)


def custom_response(res, status_code):
    return Response(
        mimetype="algorithm/json",
        response=json.dumps(res),
        status=status_code
    )
