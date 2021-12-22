#include <iostream>
#include "pbPlots.hpp"
#include "supportLib.hpp"
#include <cmath>
#include <vector>
#include <numeric>
#define N 128
#define K 16
using namespace std;

vector<double> x;
vector<double> y;

double Norm(float *vec, int s)
{
    // l2-norm
    double accum = 0.;
    for (int i = 0; i < s; i++)
    {
        accum += vec[i] * vec[i];
    }
    double norm = sqrt(accum);
    y.push_back(norm);
    return norm;
}

void gauss_seidler()
{
    float Ax[N][N];
    float e[N];
    float x[N];
    float x1[N];

    for(int i = 0 ; i < N ; i++)
    {
        for(int j = 0 ; j < N ; j++)
        {
            if(i == j) Ax[i][j] = 4;
            else if(j == i - 1 || j == i + 1 || j == i - 4 || j == i + 4) Ax[i][j] = 1;
            else Ax[i][j] = 0;
        }
    }

    for(int i = 0 ; i < N ; i++)
        e[i] = 1;

    for(int i = 0 ; i < N ; i++)
        x[i] = 0;

    float x_roznica[N];
    for(int i = 0 ; i < N ; i++)
        x_roznica[i] = 0;

    for(int k = 0 ; k < K ; k++ )
    {
        cout << endl << "Iteracja nr. " << k << endl;

        for(int i = 0 ; i < N ; i++)
        {
            x1[i] = e[i];

            if( i >= 4 )
            {
                x1[i] -= Ax[i][i-4] * x1[i-4];
            }
            if( i >= 1 )
            {
                x1[i] -= Ax[i][i-1] * x1[i-1];
            }
            if( N - i > 1 )
            {
                x1[i] -= Ax[i][i+1] * x[i+1];
            }
            if( N - i > 4 )
            {
                x1[i] -= Ax[i][i+4] * x[i+4];
            }

            x1[i] /= Ax[i][i];

            cout << x1[i] << " ";
        }
        cout << endl;

        for(int i = 0 ; i < N ; i++)
        {
            x_roznica[i] = x1[i] - x[i];
            x[i] = x1[i];
        }

        cout << endl << Norm(x_roznica,N) << endl;

    }
}

vector<float> vectorPlusScalarTimesVector( const vector<float> &U, float b, const vector<float> &V )        // Linear combination of vectors
{
    int n = U.size();
    vector<float> W( n );
    for ( int j = 0; j < n; j++ ) W[j] = U[j] + b * V[j];
    return W;
}

float transpozedVectorTimesVector( const vector<float> &U, const vector<float> &V )
{
    return inner_product( U.begin(), U.end(), V.begin(), 0.0 );
}

vector<float> matrixTimesVector( const vector<vector<float>> &A, const vector<float> &V )
{
    int n = A.size();
    vector<float> C( n );
    for ( int i = 0; i < n; i++ )
    {
        C[i] = A[i][i]*V[i];
        if( i >= 4 )
        {
            C[i] += A[i][i-4] * V[i-4];
        }
        if( i >= 1 )
        {
            C[i] += A[i][i-1] * V[i-1];
        }
        if( N - i > 1 )
        {
            C[i] += A[i][i+1] * V[i+1];
        }
        if( N - i > 4 )
        {
            C[i] += A[i][i+4] * V[i+4];
        }
    }

    return C;
}

double vectorNorm( const vector<float> &V )
{
    double norm = sqrt( transpozedVectorTimesVector( V, V ) );
    y.push_back(norm);
    return norm;
}

void gradients()
{
    vector<vector<float>> Ax(N);
    vector<float> e(N);

    for(int i = 0 ; i < N ; i++)
    {
        Ax[i] = vector<float>(N);
        for(int j = 0 ; j < N ; j++)
        {
            if(i == j) Ax[i][j] = 4;
            else if(j == i - 1 || j == i + 1 || j == i - 4 || j == i + 4) Ax[i][j] = 1;
            else Ax[i][j] = 0;
        }
    }

    for(int j = 0 ; j < N ; j++)
    {
        e[j] = 1;
    }

    vector<float> X( N, 0.0 );
    vector<float> X_last = X;
    vector<float> R = e;
    vector<float> P = R;
    int k = 0;

    for ( int k = 0 ; k < K ; k++ )
    {
        vector<float> Rold = R;
        vector<float> AP = matrixTimesVector( Ax, P );

        float alpha = transpozedVectorTimesVector( R, R ) / transpozedVectorTimesVector( P, AP );
        X = vectorPlusScalarTimesVector( X, alpha, P );

        cout << "Iteracja nr." << k << endl;
        for(auto a : X)
        {
            cout << a << " ";
        }
        cout << endl;
        cout << vectorNorm(vectorPlusScalarTimesVector(X,-1.0,X_last)) << endl;


        R = vectorPlusScalarTimesVector( R, -alpha, AP );
        float beta = transpozedVectorTimesVector( R, R ) / transpozedVectorTimesVector( Rold, Rold );
        P = vectorPlusScalarTimesVector( R, beta, P );

        X_last = X;
    }
}

int main (int argc, char *argv[])
{

    RGBABitmapImageReference *imgRef = CreateRGBABitmapImageReference();

    for(int i = 0 ; i < K ; i++)
        x.push_back(i);

    gauss_seidler();

    DrawScatterPlot(imgRef,1920,1080,&x,&y);
    vector<double> *pingData = ConvertToPNG(imgRef->image);
    WriteToFile(pingData,"chart.png");
    DeleteImage(imgRef->image);
    delete pingData;

    y.clear();
    cout << endl << "########################################################################################################" << endl;
    gradients();

    RGBABitmapImageReference *img = CreateRGBABitmapImageReference();
    DrawScatterPlot(img,1920,1080,&x,&y);
    vector<double> *pngData = ConvertToPNG(img->image);
    WriteToFile(pngData,"chart2.png");
    DeleteImage(img->image);
    delete pngData;


    return 0;
}
