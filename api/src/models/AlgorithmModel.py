from marshmallow import fields, Schema
import datetime
from . import db


class AlgorithmModel(db.Model):

    __tablename__ = 'algorithms'

    id = db.Column(db.Integer, primary_key=True)
    name = db.Column(db.String(128), nullable=False)
    created_at = db.Column(db.DateTime)
    modified_at = db.Column(db.DateTime)

    def __init__(self, data):
        self.name = data.get('name')
        self.created_at = datetime.datetime.utcnow()
        self.modified_at = datetime.datetime.utcnow()

    def save(self):
        db.session.add(self)
        db.session.commit()

    def update(self, data):
        for key, item in data.items():
            setattr(self, key, item)
        self.modified_at = datetime.datetime.utcnow()
        db.session.commit()

    def delete(self):
        db.session.delete(self)
        db.session.commit()

    @staticmethod
    def get_all_algorithms():
        return AlgorithmModel.query.all()

    @staticmethod
    def get_algorithm_by_id(id):
        return AlgorithmModel.query.get(id)

    @staticmethod
    def get_algorithm_by_name(name):
        return AlgorithmModel.query.filter_by(name=name).first()

    def __repr(self):
        return '<id {}>'.format(self.id)


class AlgorithmSchema(Schema):
    id = fields.Int(dump_only=True)
    name = fields.Str(required=True)
    created_at = fields.DateTime(dump_only=True)
    modified_at = fields.DateTime(dump_only=True)
