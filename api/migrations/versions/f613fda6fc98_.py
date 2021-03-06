"""empty message

Revision ID: f613fda6fc98
Revises: c527bdc79b5e
Create Date: 2021-03-28 02:00:00.476185

"""
from alembic import op
import sqlalchemy as sa


# revision identifiers, used by Alembic.
revision = 'f613fda6fc98'
down_revision = 'c527bdc79b5e'
branch_labels = None
depends_on = None


def upgrade():
    # ### commands auto generated by Alembic - please adjust! ###
    op.add_column('configurations', sa.Column('algorithm_id', sa.Integer(), nullable=False))
    op.add_column('configurations', sa.Column('application_id', sa.Integer(), nullable=False))
    op.create_foreign_key(None, 'configurations', 'algorithms', ['algorithm_id'], ['id'])
    op.create_foreign_key(None, 'configurations', 'applications', ['application_id'], ['id'])
    # ### end Alembic commands ###


def downgrade():
    # ### commands auto generated by Alembic - please adjust! ###
    op.drop_constraint(None, 'configurations', type_='foreignkey')
    op.drop_constraint(None, 'configurations', type_='foreignkey')
    op.drop_column('configurations', 'application_id')
    op.drop_column('configurations', 'algorithm_id')
    # ### end Alembic commands ###
